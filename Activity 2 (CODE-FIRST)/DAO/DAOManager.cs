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
        private MODEL.ClassicModelDbContext context = null;
        public DAOManager(MODEL.ClassicModelDbContext context)
        {
            this.context = context;
        }

        public bool AddCustomer(Customer customer)
        {
            
        }

        public bool AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool AddOffice(Office office)
        {
            throw new NotImplementedException();
        }

        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public bool AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool AddProductLine(ProductLines productLines)
        {
            throw new NotImplementedException();
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
    }
} 

