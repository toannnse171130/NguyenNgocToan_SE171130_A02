using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; private set; }

        public CustomerDialog(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            DataContext = Customer;
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
