using Activity_2__CODE_FIRST_.MODEL;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.DAO
{
    public class DAOManager : IDAOManager
    {
        private const string CUSTOMERS_FILENAME = "CSV/CUSTOMERS.CSV";
        private const string EMPLOYEES_FILENAME = "CSV/EMPLOYEES.CSV";
        private const string OFFICES_FILENAME = "CSV/OFFICES.CSV";
        private const string ORDERDETAILS_FILENAME = "CSV/ORDERDETAILS.CSV";
        private const string ORDERS_FILENAME = "CSV/ORDERS.CSV";
        private const string PAYMENTS_FILENAME = "CSV/PAYMENTS.CSV";
        private const string PRODUCTLINES_FILENAME = "CSV/PRODUCTLINES.CSV";
        private const string PRODUCTS_FILENAME = "CSV/PRODUCTS.CSV";
        private MODEL.ClassicModelDbContext context = null;
        public DAOManager()
        {
            this.context = new ClassicModelDbContext();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public List<Office> GetOffices()
        {
            return context.Offices.ToList();
        }

        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        public List<Payment> GetPayments()
        {
            return context.Payments.ToList();
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<ProductLines> GetProductLines()
        {
            return context.ProductLiness.ToList();
        }

        public List<Payment> GetPaymentsByCustomer(Customer customer)
        {
            List<Payment> payments = context.Payments
                .AsQueryable()
                .Where(p => p.CustomerNumber == customer.CustomerNumber)
                .Select(p => new Payment
                {
                    CustomerNumber = p.CustomerNumber,
                    CheckNumber = p.CheckNumber,
                    PaymentDate = p.PaymentDate,
                    Amount = p.Amount,
                    Customer = customer
                })
                .ToList();

            return payments;
        }
        public List<Customer> GetCustomersWithPaymentsGreaterThan(double amount)
        {
            List<Customer> customers = context.Customers
                .AsQueryable()
                .Where(c => c.Payments != null && c.Payments.Any(p => p.Amount > amount))
                .Select(c => new Customer
                {
                    CustomerNumber = c.CustomerNumber,
                    CustomerName = c.CustomerName,
                    ContactLastName = c.ContactLastName,
                    ContactFirstName = c.ContactFirstName,
                    Phone = c.Phone,
                    AdressLine1 = c.AdressLine1,
                    AdressLine2 = c.AdressLine2,
                    City = c.City,
                    State = c.State,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    SalesRepEmployeeNumber = c.SalesRepEmployeeNumber,
                    CreditLimit = c.CreditLimit,
                    Employee = c.Employee,
                    Payments = c.Payments,
                    Orders = c.Orders
                })
                .ToList();

            return customers;
        }
        public List<Order> GetOrdersByYear(int year)
        {
            List<Order> orders = context.Orders
                .AsQueryable()
                .Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Year == year)
                .OrderBy(o => o.OrderDate)
                .ToList();

            return orders;
        }
        public List<Customer> GetCustomersByProductCode(string productCode)
        {
            List<Customer> customers = context.Customers
                .AsQueryable()
                .Where(c => c.Orders != null && c.Orders.Any(
                       o => o.OrdersDetails != null && o.OrdersDetails.Any(
                       od => od.ProductCode == productCode)))
                .Select(c => new Customer
                {
                    CustomerNumber = c.CustomerNumber,
                    CustomerName = c.CustomerName,
                    ContactLastName = c.ContactLastName,
                    ContactFirstName = c.ContactFirstName,
                    Phone = c.Phone,
                    AdressLine1 = c.AdressLine1,
                    AdressLine2 = c.AdressLine2,
                    City = c.City,
                    State = c.State,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    SalesRepEmployeeNumber = c.SalesRepEmployeeNumber,
                    CreditLimit = c.CreditLimit,
                    Employee = c.Employee,
                    Payments = c.Payments,
                    Orders = c.Orders.Where(o => o.OrdersDetails != null && o.OrdersDetails.Any(od => od.ProductCode == productCode)).ToList(),
                })
                .ToList();

            return customers;
        }
        public List<Employee> GetEmployeesWithSalesExceedingAmount(double amount)
        {
            List<Employee> employees = context.Employees
                .AsQueryable()
                .Where(e => e.Customers != null && e.Customers.Any(
                       c => c.Payments != null && c.Payments.Sum(
                       p => p.Amount) > amount))
                .Select(e => new Employee
                {
                    EmployeeNumber = e.EmployeeNumber,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Extension = e.Extension,
                    Email = e.Email,
                    OfficeCode = e.OfficeCode,
                    ReportsTo = e.ReportsTo,
                    JobTitle = e.JobTitle,
                    Office = e.Office,
                    ReportedEmployee = e.ReportedEmployee,
                    Customers = e.Customers.Where(c => c.Payments != null && c.Payments.Sum(p => p.Amount) > amount).ToList(),
                })
                .ToList();

            return employees;
        }
        public List<Employee> GetEmployeesInSameOfficeAsManager()
        {
            List<Employee> employees = context.Employees
                .AsQueryable()
                .Where(e => e.OfficeCode != null && e.ReportsTo != null && e.OfficeCode == e.ReportedEmployee.OfficeCode)
                .Select(e => new Employee
                {
                    EmployeeNumber = e.EmployeeNumber,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Extension = e.Extension,
                    Email = e.Email,
                    OfficeCode = e.OfficeCode,
                    ReportsTo = e.ReportsTo,
                    JobTitle = e.JobTitle,
                    Office = e.Office,
                    ReportedEmployee = e.ReportedEmployee,
                    Customers = e.Customers
                })
                .ToList();

            return employees;
        }

        public List<Product> GetBestSellingProducts()
        {
            var products = context.Products
                .Include(p => p.OrdersDetails)
                .OrderByDescending(p => p.OrdersDetails.Sum(od => od.QuantityOrdered))
                .ToList();

            return products;
        }

        public List<Customer> GetCustomersWithMostOrders()
        {
            var customers = context.Customers
                .Include(c => c.Orders)
                .OrderByDescending(c => c.Orders.Count)
                .ToList();

            return customers;
        }

        public List<Employee> GetEmployeesWithHighestSales()
        {
            var employees = context.Employees
                .Include(e => e.Customers)
                .ThenInclude(c => c.Payments)
                .OrderByDescending(e => e.Customers.Sum(c => c.Payments.Sum(p => p.Amount)))
                .ToList();

            return employees;
        }

        public List<Order> GetOrdersExceedingShippingDeadline()
        {
            var orders = context.Orders
                .AsQueryable()
                .Where(o => o.ShippedDate == null && o.RequiredDate < DateTime.Now)
                .ToList();

            return orders;
        }

        public List<Product> GetProductsByProfitMargin()
        {
            var products = context.Products
                .AsQueryable()
                .OrderByDescending(p => p.BuyPrice - p.MSRP)
                .ToList();

            return products;
        }

        public List<Customer> GetCustomersWithOverduePayments()
        {
            var customers = context.Customers
                .Include(c => c.Payments)
                .Where(c => c.Payments.Any(p => DateTime.Parse(p.PaymentDate) < DateTime.Now))
                .ToList();

            return customers;
        }



        #region addRegion

        public bool AddCustomer(Customer customer)
        {
            customer.Employee = context.Employees.Find(customer.SalesRepEmployeeNumber);
            context.Customers.Add(customer);
            return context.SaveChanges() > 0;
        }

        public bool AddEmployee(Employee employee)
        {
            employee.Office = context.Offices.Find(employee.OfficeCode);
            employee.ReportedEmployee = context.Employees.Find(employee.ReportsTo);
            context.Employees.Add(employee);
            return context.SaveChanges() > 0;
        }

        public bool AddOffice(Office office)
        {
            context.Offices.Add(office);
            return context.SaveChanges() > 0;
        }

        public bool AddOrder(Order order)
        {
            order.Customer = context.Customers.Find(order.CustomerNumber);
            context.Orders.Add(order);
            return context.SaveChanges() > 0;
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetail.Order = context.Orders.Find(orderDetail.OrderNumber);
            orderDetail.Product = context.Products.Find(orderDetail.ProductCode);
            context.OrderDetails.Add(orderDetail);
            return context.SaveChanges() > 0;
        }

        public bool AddPayment(Payment payment)
        {
            payment.Customer = context.Customers.Find(payment.CustomerNumber);
            context.Payments.Add(payment);
            return context.SaveChanges() > 0;
        }

        public bool AddProduct(Product product)
        {
            product.ProductLines = context.ProductLiness.Find(product.ProductLine);
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }

        public bool AddProductLine(ProductLines productLines)
        {
            context.ProductLiness.Add(productLines);
            return context.SaveChanges() > 0;
        }

        #endregion

        #region importRegion
        public static T? ParseField<T>(string value) where T : struct
        {
            if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
            {
                return null; // Devuelve null para tipos de valor anulables
            }
            else
            {
                // Usa Convert.ChangeType para convertir el valor al tipo correspondiente
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        public static string ParseField(string value)
        {
            return string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase) ? null : value;
        }



        public void ImportCustomers(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var customer = new Customer();
                    customer.CustomerNumber = ParseField<int>(csv.GetField("customerNumber"));
                    customer.CustomerName = ParseField(csv.GetField("customerName"));
                    customer.ContactLastName = ParseField(csv.GetField("contactLastName"));
                    customer.ContactFirstName = ParseField(csv.GetField("contactFirstName"));
                    customer.Phone = ParseField(csv.GetField("phone"));
                    customer.AdressLine1 = ParseField(csv.GetField("addressLine1"));
                    customer.AdressLine2 = ParseField(csv.GetField("addressLine2"));
                    customer.City = ParseField(csv.GetField("city"));
                    customer.State = ParseField(csv.GetField("state"));
                    customer.PostalCode = ParseField(csv.GetField("postalCode"));
                    customer.Country = ParseField(csv.GetField("country"));
                    customer.SalesRepEmployeeNumber = ParseField<int>(csv.GetField("salesRepEmployeeNumber"));
                    customer.CreditLimit = ParseField<double>(csv.GetField("creditLimit"));
                    AddCustomer(customer);
                }
            }
        }

        public void ImportEmployees(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var employee = new Employee();

                    employee.EmployeeNumber = ParseField<int>(csv.GetField("employeeNumber"));
                    employee.LastName = ParseField(csv.GetField("lastName"));
                    employee.FirstName = ParseField(csv.GetField("firstName"));
                    employee.Extension = ParseField(csv.GetField("extension"));
                    employee.Email = ParseField(csv.GetField("email"));
                    employee.OfficeCode = ParseField(csv.GetField("officeCode"));
                    employee.ReportsTo = ParseField<int>(csv.GetField("reportsTo"));
                    employee.JobTitle = ParseField(csv.GetField("jobTitle"));
                    AddEmployee(employee);
                }

                
            }
        }

        public void ImportOffices(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var office = new Office();
                    office.OfficeCode = ParseField(csv.GetField("officeCode"));
                    office.City = ParseField(csv.GetField("city"));
                    office.Phone = ParseField(csv.GetField("phone"));
                    office.AdressLine1 = ParseField(csv.GetField("addressLine1"));
                    office.AdressLine2 = ParseField(csv.GetField("addressLine2"));
                    office.State = ParseField(csv.GetField("state"));
                    office.Country = ParseField(csv.GetField("country"));
                    office.PostalCode = ParseField(csv.GetField("postalCode"));
                    office.Territory = ParseField(csv.GetField("territory"));

                    AddOffice(office);
                }
            }
        }


        public void ImportOrderDetails(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.OrderNumber = ParseField<int>(csv.GetField("orderNumber"));
                    orderDetail.ProductCode = ParseField(csv.GetField("productCode"));
                    orderDetail.QuantityOrdered = ParseField<int>(csv.GetField("quantityOrdered"));
                    orderDetail.PriceEach = ParseField<double>(csv.GetField("priceEach"));
                    orderDetail.OrderLineNumber = ParseField<short>(csv.GetField("orderLineNumber"));
                    

                    AddOrderDetail(orderDetail);
                }
            }
        }

        public void ImportOrders(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var order = new Order();
                    order.OrderNumber = ParseField<int>(csv.GetField("orderNumber"));
                    order.OrderDate = ParseField<DateTime>(csv.GetField("orderDate"));
                    order.RequiredDate = ParseField<DateTime>(csv.GetField("requiredDate"));
                    order.ShippedDate = ParseField<DateTime>(csv.GetField("shippedDate"));
                    order.Status = ParseField(csv.GetField("status"));
                    order.Comments = ParseField(csv.GetField("comments"));
                    order.CustomerNumber = ParseField<int>(csv.GetField("customerNumber"));



                    AddOrder(order);
                }
            }
        }


        public void ImportPayments(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var payment = new Payment();
                    payment.CustomerNumber = ParseField<int>(csv.GetField("customerNumber"));
                    payment.CheckNumber = ParseField(csv.GetField("checkNumber"));
                    payment.PaymentDate = ParseField(csv.GetField("paymentDate"));
                    payment.Amount = ParseField<double>(csv.GetField("amount"));



                    AddPayment(payment);
                }
            }
        }

        public void ImportProduct(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var product = new Product();
                    product.ProductCode = ParseField(csv.GetField("productCode"));
                    product.ProductName = ParseField(csv.GetField("productName"));
                    product.ProductLine = ParseField(csv.GetField("productLine"));
                    product.ProductScale = ParseField(csv.GetField("productScale"));
                    product.ProductVendor = ParseField(csv.GetField("productVendor"));
                    product.ProductDescription = ParseField(csv.GetField("productDescription"));
                    product.QuantityStock = ParseField<short>(csv.GetField("quantityInStock"));
                    product.BuyPrice = ParseField<double>(csv.GetField("buyPrice"));
                    product.MSRP = ParseField<double>(csv.GetField("MSRP"));




                    AddProduct(product);
                }
            }
        }

        public void ImportProductLines(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();


                while (csv.Read())
                {
                    var productLine = new ProductLines();
                    productLine.ProductLine = ParseField(csv.GetField("productLine"));
                    productLine.TextDescription = ParseField(csv.GetField("textDescription"));
                    productLine.HtmlDescription = ParseField(csv.GetField("htmlDescription"));
                    productLine.Image = ParseField(csv.GetField("image"));
                    
                    AddProductLine(productLine);
                }
            }
        }

        public void ImportAll()
        {
            ImportProductLines(PRODUCTLINES_FILENAME);
            ImportProduct(PRODUCTS_FILENAME);
            ImportOffices(OFFICES_FILENAME);
            ImportEmployees(EMPLOYEES_FILENAME);
            ImportCustomers(CUSTOMERS_FILENAME);
            ImportPayments(PAYMENTS_FILENAME);
            ImportOrders(ORDERS_FILENAME);
            ImportOrderDetails(ORDERDETAILS_FILENAME);
        }

        #endregion



    }
} 

