using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderDetailViewModel : INotifyPropertyChanged
    {
        private readonly OrderDetailService _service;
        private ObservableCollection<OrderDetail> _orderDetails;
        private OrderDetail _selectedOrderDetail;
        public event PropertyChangedEventHandler PropertyChanged;

        public OrderDetailViewModel()
        {
            _service = new OrderDetailService();
            _orderDetails = new ObservableCollection<OrderDetail>(_service.GetAllOrderDetails());
        }

        public ObservableCollection<OrderDetail> OrderDetails
        {
            get => _orderDetails;
            set { _orderDetails = value; OnPropertyChanged(); }
        }

        public OrderDetail SelectedOrderDetail
        {
            get => _selectedOrderDetail;
            set { _selectedOrderDetail = value; OnPropertyChanged(); }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            var validationResults = ValidationService.Validate(orderDetail);
            if (validationResults.Count == 0)
            {
                _service.AddOrderDetail(orderDetail);
                OrderDetails.Add(orderDetail);
            }
            // else: handle validation errors
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var validationResults = ValidationService.Validate(orderDetail);
            if (validationResults.Count == 0)
            {
                _service.UpdateOrderDetail(orderDetail);
                // Optionally refresh OrderDetails collection
            }
            // else: handle validation errors
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            _service.DeleteOrderDetail(new { orderDetail.OrderId, orderDetail.ProductId });
            OrderDetails.Remove(orderDetail);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
