using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeService _service;
        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;
        public event PropertyChangedEventHandler PropertyChanged;

        public EmployeeViewModel()
        {
            _service = new EmployeeService();
            _employees = new ObservableCollection<Employee>(_service.GetAllEmployees());
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set { _employees = value; OnPropertyChanged(); }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { _selectedEmployee = value; OnPropertyChanged(); }
        }

        public void AddEmployee(Employee employee)
        {
            var validationResults = ValidationService.Validate(employee);
            if (validationResults.Count == 0)
            {
                _service.AddEmployee(employee);
                Employees.Add(employee);
            }
            // else: handle validation errors
        }

        public void UpdateEmployee(Employee employee)
        {
            var validationResults = ValidationService.Validate(employee);
            if (validationResults.Count == 0)
            {
                _service.UpdateEmployee(employee);
                // Optionally refresh Employees collection
            }
            // else: handle validation errors
        }

        public void DeleteEmployee(Employee employee)
        {
            _service.DeleteEmployee(employee.EmployeeId);
            Employees.Remove(employee);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
