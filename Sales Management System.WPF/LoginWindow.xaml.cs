using System.Windows;
using SalesManagementSystem.DataAcces.Models;
using System.Linq;
using Sales_Management_System.WPF;

namespace SalesManagementSystem.WPF
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void EmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = EmployeeUserNameBox.Text.Trim();
            string password = EmployeePasswordBox.Password.Trim();
            using (var db = new LucySalesDataContext())
            {
                var emp = db.Employees.FirstOrDefault(x => x.UserName == username && x.Password == password);
                if (emp != null)
                {
                    // Open MainMenuWindow for Admin/Employee
                    var menu = new MainMenuWindow(emp);
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void CustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = CustomerPhoneBox.Text.Trim();
            using (var db = new LucySalesDataContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.Phone == phone);
                if (customer != null)
                {
                    // Open CustomerProfileWindow for Customer
                    var profile = new CustomerProfileWindow(customer);
                    profile.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Phone number not found.");
                }
            }
        }
    }
}