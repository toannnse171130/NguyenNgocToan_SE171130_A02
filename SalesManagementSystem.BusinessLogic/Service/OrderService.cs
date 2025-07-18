using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService()
        {
            _orderRepository = new Repository<Order>();
        }

        public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAll();

        public Order GetOrderById(int id) => _orderRepository.GetById(id);

        public void AddOrder(Order order)
        {
            _orderRepository.Insert(order);
            _orderRepository.Save();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            _orderRepository.Save();
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
        }
    }
}
