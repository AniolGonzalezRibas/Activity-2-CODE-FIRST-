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

        public void ImportCustomers(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var customers = csv.GetRecords<Customer>();
                foreach (var customer in customers)
                {
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

                    employee.EmployeeNumber = csv.GetField<int>("employeeNumber");
                    employee.LastName = csv.GetField("lastName");
                    employee.FirstName = csv.GetField("firstName");
                    employee.Extension = csv.GetField("extension");
                    employee.Email = csv.GetField("email");
                    employee.OfficeCode = csv.GetField("officeCode");
                    string reportsToString = csv.GetField("reportsTo");
                    employee.ReportsTo = string.Equals(reportsToString, "NULL", StringComparison.OrdinalIgnoreCase) ? null : (int?)int.Parse(reportsToString);

                    employee.JobTitle = csv.GetField("jobTitle");

                    AddEmployee(employee);
                }

                
            }
        }

        public void ImportOffices(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var offices = csv.GetRecords<Office>();

                foreach (var office in offices)
                {
                    AddOffice(office);
                }
            }
        }


        public void ImportOrderDetails(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var orderDetails = csv.GetRecords<OrderDetail>();

                foreach (var orderDetail in orderDetails)
                {
                    AddOrderDetail(orderDetail);
                }
            }
        }

        public void ImportOrders(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var orders = csv.GetRecords<Order>();

                foreach (var order in orders)
                {
                    AddOrder(order);
                }
            }
        }


        public void ImportPayments(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var payments = csv.GetRecords<Payment>();

                foreach (var payment in payments)
                {
                    AddPayment(payment);
                }
            }
        }

        public void ImportProduct(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var products = csv.GetRecords<Product>();

                foreach (var product in products)
                {
                    AddProduct(product);
                }
            }
        }

        public void ImportProductLines(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var productsLines = csv.GetRecords<ProductLines>();

                foreach (var productLines in productsLines)
                {
                    AddProductLine(productLines);
                }
            }
        }

        public void ImportAll()
        {
            //ImportProductLines(PRODUCTLINES_FILENAME);
            //ImportProduct(PRODUCTS_FILENAME);
            //ImportOffices(OFFICES_FILENAME);
            ImportEmployees(EMPLOYEES_FILENAME);
            ImportCustomers(CUSTOMERS_FILENAME);
            ImportPayments(PAYMENTS_FILENAME);
            ImportOrders(ORDERS_FILENAME);
            ImportOrderDetails(ORDERDETAILS_FILENAME);
        }
    }
} 

