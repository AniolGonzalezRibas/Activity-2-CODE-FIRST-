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
        private static T? ParseField<T>(string? value) where T : struct
        {
            if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            else
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
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
                    customer.CustomerName = ParseField<string>(csv.GetField("customerName"));
                    customer.ContactLastName = ParseField<string>(csv.GetField("contactLastName"));
                    customer.ContactFirstName = ParseField<string>(csv.GetField("contactFirstName"));
                    customer.Phone = ParseField<string>(csv.GetField("phone"));
                    customer.AdressLine1 = ParseField<string>(csv.GetField("addressLine1"));
                    customer.AdressLine2 = ParseField<string>(csv.GetField("addressLine2"));
                    customer.City = ParseField<string>(csv.GetField("city"));
                    customer.State = ParseField<string>(csv.GetField("state"));
                    customer.PostalCode = ParseField<string>(csv.GetField("postalCode"));
                    customer.Country = ParseField<string>(csv.GetField("country"));
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
                    employee.LastName = ParseField<string>(csv.GetField("lastName"));
                    employee.FirstName = ParseField<string>(csv.GetField("firstName"));
                    employee.Extension = ParseField<string>(csv.GetField("extension"));
                    employee.Email = ParseField<string>(csv.GetField("email"));
                    employee.OfficeCode = ParseField<string>(csv.GetField("officeCode"));
                    employee.ReportsTo = ParseField<int?>(csv.GetField("reportsTo"));
                    employee.JobTitle = ParseField<string>(csv.GetField("jobTitle"));
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
                    office.OfficeCode = ParseField<string>(csv.GetField("officeCode"));
                    office.City = ParseField<string>(csv.GetField("city"));
                    office.Phone = ParseField<string>(csv.GetField("phone"));
                    office.AdressLine1 = ParseField<string>(csv.GetField("addressLine1"));
                    office.AdressLine2 = ParseField<string>(csv.GetField("addressLine2"));
                    office.State = ParseField<string>(csv.GetField("state"));
                    office.Country = ParseField<string>(csv.GetField("country"));
                    office.PostalCode = ParseField<string>(csv.GetField("postalCode"));
                    office.Territory = ParseField<string>(csv.GetField("territory"));

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
                    orderDetail.ProductCode = ParseField<string>(csv.GetField("productCode"));
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
                    order.Status = ParseField<string>(csv.GetField("status"));
                    order.Comments = ParseField<string>(csv.GetField("comments"));
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
                    payment.CheckNumber = ParseField<string>(csv.GetField("checkNumber"));
                    payment.PaymentDate = ParseField<string>(csv.GetField("paymentDate"));
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
                    product.ProductCode = ParseField<string>(csv.GetField("productCode"));
                    product.ProductName = ParseField<string>(csv.GetField("productName"));
                    product.ProductLine = ParseField<string>(csv.GetField("productLine"));
                    product.ProductScale = ParseField<string>(csv.GetField("productScale"));
                    product.ProductVendor = ParseField<string>(csv.GetField("productVendor"));
                    product.ProductDescription = ParseField<string>(csv.GetField("productDescription"));
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
                    productLine.ProductLine = ParseField<string>(csv.GetField("productLine"));
                    productLine.TextDescription = ParseField<string>(csv.GetField("textDescription"));
                    productLine.HtmlDescription = ParseField<string>(csv.GetField("htmlDescription"));
                    productLine.Image = ParseField<string>(csv.GetField("image"));
                    
                    AddProductLine(productLine);
                }
            }
        }

        public void ImportAll()
        {
            //ImportProductLines(PRODUCTLINES_FILENAME);
            //ImportProduct(PRODUCTS_FILENAME);
            //ImportOffices(OFFICES_FILENAME);
            //ImportEmployees(EMPLOYEES_FILENAME);
            ImportCustomers(CUSTOMERS_FILENAME);
            ImportPayments(PAYMENTS_FILENAME);
            ImportOrders(ORDERS_FILENAME);
            ImportOrderDetails(ORDERDETAILS_FILENAME);
        }
    }
} 

