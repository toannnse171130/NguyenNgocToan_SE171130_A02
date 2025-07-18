using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class EmployeeDialog : Window
    {
        public Employee Employee { get; private set; }

        public EmployeeDialog(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
