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



        private void btnCustomersFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmployeesFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOfficesFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSurnameFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderDetailsFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPaymentFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductsFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductLinesFilter_Click(object sender, RoutedEventArgs e)
        {

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

        }

        private void btnGetPaymentsByCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}