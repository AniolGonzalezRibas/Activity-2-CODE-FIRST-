using Activity_2__CODE_FIRST_.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.DAO
{
    public class DAOManager : IDAOManager
    {
        private const string CUSTOMERS_FILENAME = "CUSTOMERS.CSV";
        private const string EMPLOYEES_FILENAME = "EMPLOYEES.CSV";
        private const string OFFICES_FILENAME = "OFFICES.CSV";
        private const string ORDERDETAILS_FILENAME = "ORDERDETAILS.CSV";
        private const string ORDERS_FILENAME = "ORDERS.CSV";
        private const string PAYMENTS_FILENAME = "PAYMENTS.CSV";
        private const string PRODUCTLINES_FILENAME = "PRODUCTLINES.CSV";
        private const string PRODUCTS_FILENAME = "PRODUCTS.CSV";
        private MODEL.ClassicModelDbContext context = null;
        public DAOManager(MODEL.ClassicModelDbContext context)
        {
            this.context = context;
        }

        public bool AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges() > 0;
        }

        public bool AddEmployee(Employee employee)
        {
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
            context.Orders.Add(order);
            return context.SaveChanges() > 0;
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
            return context.SaveChanges() > 0;
        }

        public bool AddPayment(Payment payment)
        {
            context.Payments.Add(payment);
            return context.SaveChanges() > 0;
        }

        public bool AddProduct(Product product)
        {
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }

        public bool AddProductLine(ProductLines productLines)
        {
            context.ProductLiness.Add(productLines);
            return context.SaveChanges() > 0;
        }

        public void ImportCustomers(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    Customer customer = new Customer
                    {
                        CustomerNumber = int.Parse(parts[0]),
                        CustomerName = parts[1],
                        ContactLastName = parts[2],
                        ContactFirstName = parts[3],
                        Phone = parts[4],
                        AdressLine1 = parts[5],
                        AdressLine2 = parts[6],
                        City = parts[7],
                        State = parts[8],
                        PostalCode = parts[9],
                        SalesRepEmployeeNumber = int.Parse(parts[10]),
                        CreditLimit = double.Parse(parts[12])
                    };
                    AddCustomer(customer);
                    line = reader.ReadLine();
                }
            }
        }

        public void ImportEmployees(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    Employee employee = new Employee
                    {
                        EmployeeNumber = int.Parse(parts[0]),
                        LastName = parts[1],
                        FirstName = parts[2],
                        Extension = parts[3],
                        Email = parts[4],
                        OfficeCode = parts[5],
                        ReportsTo = string.IsNullOrEmpty(parts[6]) ? null : int.Parse(parts[6]),
                        JobTitle = parts[7]
                    };
                    AddEmployee(employee);
                    line = reader.ReadLine();
                }
            }
        }

        public void ImportOffices(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    Office office = new Office
                    {
                        OfficeCode = parts[0],
                        City = parts[1],
                        Phone = parts[2],
                        AdressLine1 = parts[3],
                        AdressLine2 = parts[4],
                        State = parts[5],
                        Country = parts[6],
                        PostalCode = parts[7],
                        Territory = parts[8]
                    };
                    AddOffice(office);
                    line = reader.ReadLine();
                }
            }
        }


        public void ImportOrderDetails(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderNumber = int.Parse(parts[0]),
                        ProductCode = parts[1],
                        QuantityOrdered = int.Parse(parts[2]),
                        PriceEach = double.Parse(parts[3]),
                        OrderLineNumber = short.Parse(parts[4])
                    };
                    AddOrderDetail(orderDetail);
                    line = reader.ReadLine();
                }
            }
        }

        public void ImportOrders(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    Order order = new Order
                    {
                        OrderNumber = int.Parse(parts[0]),
                        OrderDate = DateTime.Parse(parts[1]),
                        RequiredDate = DateTime.Parse(parts[2]),
                        ShippedDate = DateTime.Parse(parts[3]),
                        Status = parts[4],
                        Comments = parts[5],
                        CustomerNumber = int.Parse(parts[6])
                    };
                    AddOrder(order);
                    line = reader.ReadLine();
                }
            }
        }


        public void ImportPayments(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                String line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    String[] parts = line.Split(',');
                    Payment payment = new Payment
                    {
                        CustomerNumber = int.Parse(parts[0]),
                        CheckNumber = parts[1],
                        PaymentDate = parts[2],
                        Amount = double.Parse(parts[3])
                    };
                    AddPayment(payment);
                    line = reader.ReadLine();
                }
            }
        }

        public void ImportProduct(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportProductLines(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportAll()
        {
            ImportCustomers(CUSTOMERS_FILENAME);
            ImportEmployees(EMPLOYEES_FILENAME);
            ImportOffices(OFFICES_FILENAME);
            ImportOrderDetails(ORDERDETAILS_FILENAME);
            ImportOrders(ORDERS_FILENAME);
            ImportPayments(PAYMENTS_FILENAME);
            ImportProduct(PRODUCTS_FILENAME);
            ImportProductLines(PRODUCTLINES_FILENAME);
        }
    }
} 

