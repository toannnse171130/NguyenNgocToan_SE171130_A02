using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class OrderDetailView : Window
    {
        private OrderDetailViewModel _viewModel;

        public OrderDetailView()
        {
            InitializeComponent();
            _viewModel = new OrderDetailViewModel();
            DataContext = _viewModel;
        }

        private void AddOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OrderDetailDialog(new OrderDetail());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddOrderDetail(dialog.OrderDetail);
            }
        }

        private void EditOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedOrderDetail != null)
            {
                var detailCopy = new OrderDetail
                {
                    OrderId = _viewModel.SelectedOrderDetail.OrderId,
                    ProductId = _viewModel.SelectedOrderDetail.ProductId,
                    UnitPrice = _viewModel.SelectedOrderDetail.UnitPrice,
                    Quantity = _viewModel.SelectedOrderDetail.Quantity,
                    Discount = _viewModel.SelectedOrderDetail.Discount,
                    Product = _viewModel.SelectedOrderDetail.Product
                };
                var dialog = new OrderDetailDialog(detailCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateOrderDetail(dialog.OrderDetail);
                }
            }
        }

        private void DeleteOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedOrderDetail != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteOrderDetail(_viewModel.SelectedOrderDetail);
                }
            }
        }
    }
}
