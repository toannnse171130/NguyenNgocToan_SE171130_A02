using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _service;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerViewModel()
        {
            _service = new CustomerService();
            _customers = new ObservableCollection<Customer>(_service.GetAllCustomers());
        }

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(); }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        public void AddCustomer(Customer customer)
        {
            var validationResults = ValidationService.Validate(customer);
            if (validationResults.Count == 0)
            {
                _service.AddCustomer(customer);
                Customers.Add(customer);
            }
            // else: handle validation errors
        }

        public void UpdateCustomer(Customer customer)
        {
            var validationResults = ValidationService.Validate(customer);
            if (validationResults.Count == 0)
            {
                _service.UpdateCustomer(customer);
                // Optionally refresh Customers collection
            }
            // else: handle validation errors
        }

        public void DeleteCustomer(Customer customer)
        {
            _service.DeleteCustomer(customer.CustomerId);
            Customers.Remove(customer);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
