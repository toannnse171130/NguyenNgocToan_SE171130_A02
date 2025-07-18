using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class EmployeeView : Window
    {
        private EmployeeViewModel _viewModel;

        public EmployeeView()
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            DataContext = _viewModel;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EmployeeDialog(new Employee());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddEmployee(dialog.Employee);
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedEmployee != null)
            {
                var employeeCopy = new Employee
                {
                    EmployeeId = _viewModel.SelectedEmployee.EmployeeId,
                    Name = _viewModel.SelectedEmployee.Name,
                    UserName = _viewModel.SelectedEmployee.UserName,
                    JobTitle = _viewModel.SelectedEmployee.JobTitle,
                    BirthDate = _viewModel.SelectedEmployee.BirthDate,
                    HireDate = _viewModel.SelectedEmployee.HireDate,
                    Address = _viewModel.SelectedEmployee.Address
                };
                var dialog = new EmployeeDialog(employeeCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateEmployee(dialog.Employee);
                }
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedEmployee != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteEmployee(_viewModel.SelectedEmployee);
                }
            }
        }
    }
}
