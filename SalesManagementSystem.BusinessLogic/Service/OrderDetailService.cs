using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderDetailService
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailService()
        {
            _orderDetailRepository = new Repository<OrderDetail>();
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails() => _orderDetailRepository.GetAll();

        public OrderDetail GetOrderDetailById(object id) => _orderDetailRepository.GetById(id);

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Insert(orderDetail);
            _orderDetailRepository.Save();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
            _orderDetailRepository.Save();
        }

        public void DeleteOrderDetail(object id)
        {
            _orderDetailRepository.Delete(id);
            _orderDetailRepository.Save();
        }
    }
}
