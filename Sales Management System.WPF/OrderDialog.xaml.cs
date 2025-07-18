using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class OrderDialog : Window
    {
        public Order Order { get; private set; }

        public OrderDialog(Order order)
        {
            InitializeComponent();
            Order = order;
            DataContext = Order;
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
