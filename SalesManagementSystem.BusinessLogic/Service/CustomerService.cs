using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = new Repository<Customer>();
        }

        public IEnumerable<Customer> GetAllCustomers() => _customerRepository.GetAll();

        public Customer GetCustomerById(int id) => _customerRepository.GetById(id);

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Insert(customer);
            _customerRepository.Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            _customerRepository.Save();
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
            _customerRepository.Save();
        }
    }
}
