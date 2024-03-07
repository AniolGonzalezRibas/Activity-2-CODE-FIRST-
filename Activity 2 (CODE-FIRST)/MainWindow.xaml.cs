using Activity_2__CODE_FIRST_.DAO;
using Activity_2__CODE_FIRST_.MODEL;
using CsvHelper;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Activity_2__CODE_FIRST_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDAOManager manager;

        public MainWindow()
        {
            InitializeComponent();
            manager = DAOFactory.GetDAOManager();

            //manager.ImportAll();

            dtgCustomers.ItemsSource = manager.GetCustomers();
            dtgEmployees.ItemsSource = manager.GetEmployees();
            dtgOfficess.ItemsSource = manager.GetOffices();
            dtgOrders.ItemsSource = manager.GetOrders();
            dtgOrderDetails.ItemsSource = manager.GetOrderDetails();
            dtgPayments.ItemsSource = manager.GetPayments();
            dtgProducts.ItemsSource = manager.GetProducts();
            dtgProductLines.ItemsSource = manager.GetProductLines();

        }

        private void btnGetCustomersByProductCode_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCustumerProductCodeFilter.Text))
            {
                dtgCustomers.ItemsSource = manager.GetCustomersByProductCode(txtCustumerProductCodeFilter.Text);
            }
        }

        private void btnGetCustomersWithPaymentsGreaterThan_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCustumerPriceFilter.Text))
            {
                if (int.TryParse(txtCustumerPriceFilter.Text, out int amount))
                {
                    dtgCustomers.ItemsSource = manager.GetCustomersWithPaymentsGreaterThan(amount);
                }
                else
                    txtCustumerPriceFilter.Text = string.Empty;
            }
        }

        private void btnGetEmployeesWithSalesExceedingAmount_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSalesAmount.Text))
            {
                if (double.TryParse(txtSalesAmount.Text, out double amount))
                {
                    dtgEmployees.ItemsSource = manager.GetEmployeesWithSalesExceedingAmount(amount);
                }
                else
                    txtSalesAmount.Text = string.Empty;
            }
        }

        private void btnGetEmployeesInSameOfficeAsManager_Click(object sender, RoutedEventArgs e)
        {
            dtgEmployees.ItemsSource = manager.GetEmployeesInSameOfficeAsManager();
        }

        private void btnGetOrdersByYear_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtYear.Text))
            {
                if (int.TryParse(txtYear.Text, out int year))
                {
                    dtgOrders.ItemsSource = manager.GetOrdersByYear(year);
                }
                else
                    txtYear.Text = string.Empty;
            }
        }

        private void btnGetPaymentsByCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCustomerNumber.Text))
            {
                if (int.TryParse(txtCustomerNumber.Text, out int customerNumber))
                {
                    dtgPayments.ItemsSource = manager.GetPaymentsByCustomer(customerNumber);
                }
                else
                    txtCustomerNumber.Text = string.Empty;
            }
            else
                dtgPayments.ItemsSource = manager.GetPayments();
        }

        private void btnGetCustomersWithMostOrders_Click(object sender, RoutedEventArgs e)
        {
            dtgCustomers.ItemsSource = manager.GetCustomersWithMostOrders();
        }

        private void btnGetBestSellingProducts_Click(object sender, RoutedEventArgs e)
        {
            dtgProducts.ItemsSource = manager.GetBestSellingProducts();
        }

        private void btnGetProductsByProfitMargin_Click(object sender, RoutedEventArgs e)
        {
            dtgProducts.ItemsSource = manager.GetProductsByProfitMargin();
        }

        private void btnGetEmployeesWithHighestSales_Click(object sender, RoutedEventArgs e)
        {
            dtgEmployees.ItemsSource = manager.GetEmployeesWithHighestSales();
        }

        private void btnGetOrdersExceedingShippingDeadline_Click(object sender, RoutedEventArgs e)
        {
            dtgOrders.ItemsSource = manager.GetOrdersExceedingShippingDeadline();
        }

        private void btnGetOfficesOfManagers_Click(object sender, RoutedEventArgs e)
        {
            dtgOfficess.ItemsSource = manager.GetOfficesOfManagers();
        }

        private void btnGetOfficesByEmployeeNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOfficeEmployeeNumber.Text))
            {
                if (int.TryParse(txtOfficeEmployeeNumber.Text, out int employeeCode))
                {
                    dtgOfficess.ItemsSource = manager.GetOfficesByEmployeeCode(employeeCode);
                }
                else
                    txtOfficeEmployeeNumber.Text = string.Empty;
            }
            else
                dtgOfficess.ItemsSource = manager.GetOffices();
        }

        private void btnGetOfficesByCustomerNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOfficeCustomerNumber.Text))
            {
                if (int.TryParse(txtOfficeCustomerNumber.Text, out int customerNumber))
                {
                    dtgOfficess.ItemsSource = manager.GetOfficesByCustomerNumber(customerNumber);
                }
                else
                    txtOfficeCustomerNumber.Text = string.Empty;
            }
            else
                dtgOfficess.ItemsSource = manager.GetOffices();
        }

        
    }
}