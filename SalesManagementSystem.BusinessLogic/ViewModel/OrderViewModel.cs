using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly OrderService _service;
        private ObservableCollection<Order> _orders;
        private Order _selectedOrder;
        public event PropertyChangedEventHandler PropertyChanged;

        public OrderViewModel()
        {
            _service = new OrderService();
            _orders = new ObservableCollection<Order>(_service.GetAllOrders());
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(); }
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(); }
        }

        public void AddOrder(Order order)
        {
            var validationResults = ValidationService.Validate(order);
            if (validationResults.Count == 0)
            {
                _service.AddOrder(order);
                Orders.Add(order);
            }
            // else: handle validation errors
        }

        public void UpdateOrder(Order order)
        {
            var validationResults = ValidationService.Validate(order);
            if (validationResults.Count == 0)
            {
                _service.UpdateOrder(order);
                // Optionally refresh Orders collection
            }
            // else: handle validation errors
        }

        public void DeleteOrder(Order order)
        {
            _service.DeleteOrder(order.OrderId);
            Orders.Remove(order);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
