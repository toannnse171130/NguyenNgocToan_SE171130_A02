using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class OrderDetailDialog : Window
    {
        public OrderDetail OrderDetail { get; private set; }

        public OrderDetailDialog(OrderDetail detail)
        {
            InitializeComponent();
            OrderDetail = detail;
            DataContext = OrderDetail;
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
