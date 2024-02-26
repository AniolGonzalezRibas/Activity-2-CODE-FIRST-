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
