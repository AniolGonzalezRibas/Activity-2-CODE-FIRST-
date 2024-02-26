using Activity_2__CODE_FIRST_.MODEL;
using System;
using System.Collections.Generic;
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

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddOffice(Office office)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddProductLine(ProductLines productLines)
        {
            throw new NotImplementedException();
        }

        public void ImportCustomers(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportEmployees(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportOffices(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportOrderDetails(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportOrders(string fileName)
        {
            throw new NotImplementedException();
        }

        public void ImportPayments(string fileName)
        {
            throw new NotImplementedException();
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
