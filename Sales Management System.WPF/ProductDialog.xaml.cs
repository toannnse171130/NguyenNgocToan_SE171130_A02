using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class ProductDialog : Window
    {
        public Product Product { get; private set; }

        public ProductDialog(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;
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
