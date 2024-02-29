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
                var employees = csv.GetRecords<Employee>();

                foreach (var employee in employees)
                {
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

