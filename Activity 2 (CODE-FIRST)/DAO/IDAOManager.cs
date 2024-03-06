using Activity_2__CODE_FIRST_.MODEL;

namespace Activity_2__CODE_FIRST_.DAO
{
    public interface IDAOManager
    {
        public bool AddProductLine(ProductLines productLines);
        public bool AddProduct(Product product);
        public bool AddOffice(Office office);
        public bool AddEmployee(Employee employee);
        public bool AddCustomer(Customer customer);
        public bool AddPayment(Payment payment);
        public bool AddOrder(Order order);
        public bool AddOrderDetail(OrderDetail orderDetail);


        public void ImportProductLines(string fileName);
        public void ImportProduct(string fileName);
        public void ImportOffices(string fileName);
        public void ImportEmployees(string fileName);
        public void ImportCustomers(string fileName);
        public void ImportPayments(string fileName);
        public void ImportOrders(string fileName);
        public void ImportOrderDetails(string fileName);
     
        public void ImportAll();
      
        public List<Customer> GetCustomers();
        public List<Employee> GetEmployees();
        public List<Office> GetOffices();
        public List<Order> GetOrders();
        public List<OrderDetail> GetOrderDetails();
        public List<Payment> GetPayments();
        public List<Product> GetProducts();
        public List<ProductLines> GetProductLines();
        public List<Payment> GetPaymentsByCustomer(int customer);
        public List<Customer> GetCustomersWithPaymentsGreaterThan(double amount);
        public List<Order> GetOrdersByYear(int year);
        public List<Customer> GetCustomersByProductCode(string productCode);
        public List<Employee> GetEmployeesWithSalesExceedingAmount(double amount);
        public List<Employee> GetEmployeesInSameOfficeAsManager();
        public List<Product> GetBestSellingProducts();
        public List<Customer> GetCustomersWithMostOrders();
        public List<Employee> GetEmployeesWithHighestSales();
        public List<Order> GetOrdersExceedingShippingDeadline();
        public List<Product> GetProductsByProfitMargin();
        public List<Customer> GetCustomersWithOverduePayments();
        public List<Office> GetOfficesOfManagers();
    }
}
