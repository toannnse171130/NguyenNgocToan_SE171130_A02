using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class ProductView : Window
    {
        private ProductViewModel _viewModel;

        public ProductView()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel();
            DataContext = _viewModel;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog(new Product());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddProduct(dialog.Product);
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedProduct != null)
            {
                var productCopy = new Product
                {
                    ProductId = _viewModel.SelectedProduct.ProductId,
                    ProductName = _viewModel.SelectedProduct.ProductName,
                    UnitPrice = _viewModel.SelectedProduct.UnitPrice,
                    UnitsInStock = _viewModel.SelectedProduct.UnitsInStock,
                    Category = _viewModel.SelectedProduct.Category
                };
                var dialog = new ProductDialog(productCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateProduct(dialog.Product);
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedProduct != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteProduct(_viewModel.SelectedProduct);
                }
            }
        }
    }
}
