using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class MainMenuWindow : Window
    {
        private Employee _employee;
        public MainMenuWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            EmployeeNameText.Text = $"Welcome, {_employee.Name}!";
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            new CustomerView().ShowDialog();
        }

        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            new ProductView().ShowDialog();
        }

        private void ManageOrders_Click(object sender, RoutedEventArgs e)
        {
            new OrderView().ShowDialog();
        }

        private void ManageEmployees_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeView().ShowDialog();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            new ReportView().ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}