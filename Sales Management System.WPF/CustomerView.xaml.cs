using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class CustomerView : Window
    {
        private CustomerViewModel _viewModel;

        public CustomerView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel();
            DataContext = _viewModel;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog(new Customer());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddCustomer(dialog.Customer);
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCustomer != null)
            {
                var customerCopy = new Customer
                {
                    CustomerId = _viewModel.SelectedCustomer.CustomerId,
                    CompanyName = _viewModel.SelectedCustomer.CompanyName,
                    ContactName = _viewModel.SelectedCustomer.ContactName,
                    Phone = _viewModel.SelectedCustomer.Phone,
                    Address = _viewModel.SelectedCustomer.Address
                };
                var dialog = new CustomerDialog(customerCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateCustomer(dialog.Customer);
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCustomer != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteCustomer(_viewModel.SelectedCustomer);
                }
            }
        }
    }
}
