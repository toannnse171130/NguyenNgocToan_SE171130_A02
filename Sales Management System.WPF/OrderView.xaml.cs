using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class OrderView : Window
    {
        private OrderViewModel _viewModel;

        public OrderView()
        {
            InitializeComponent();
            _viewModel = new OrderViewModel();
            DataContext = _viewModel;
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OrderDialog(new Order());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddOrder(dialog.Order);
            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedOrder != null)
            {
                var orderCopy = new Order
                {
                    OrderId = _viewModel.SelectedOrder.OrderId,
                    Customer = _viewModel.SelectedOrder.Customer,
                    Employee = _viewModel.SelectedOrder.Employee,
                    OrderDate = _viewModel.SelectedOrder.OrderDate
                };
                var dialog = new OrderDialog(orderCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateOrder(dialog.Order);
                }
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedOrder != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteOrder(_viewModel.SelectedOrder);
                }
            }
        }
    }
}
