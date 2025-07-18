using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new Repository<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAll();

        public Employee GetEmployeeById(int id) => _employeeRepository.GetById(id);

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Insert(employee);
            _employeeRepository.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
            _employeeRepository.Save();
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
        }
    }
}
