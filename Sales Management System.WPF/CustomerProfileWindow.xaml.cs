using System.Windows;
using SalesManagementSystem.DataAcces.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesManagementSystem.WPF
{
    public partial class CustomerProfileWindow : Window
    {
        private Customer _customer;
        private List<dynamic> _allOrders;
        public CustomerProfileWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadCustomerInfo();
            LoadOrderHistory();
        }

        private void LoadCustomerInfo()
        {
            CompanyNameText.Text = _customer.CompanyName;
            ContactNameText.Text = _customer.ContactName;
            PhoneText.Text = _customer.Phone;
            AddressText.Text = _customer.Address;
        }

        private void LoadOrderHistory()
        {
            using (var db = new LucySalesDataContext())
            {
                _allOrders = db.Orders
                    .Where(o => o.CustomerId == _customer.CustomerId)
                    .Select(o => new
                    {
                        o.OrderId,
                        o.OrderDate,
                        Total = o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
                    })
                    .ToList<dynamic>();
                OrderHistoryGrid.ItemsSource = _allOrders;
            }
        }

        private void OrderSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = OrderSearchBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(search))
            {
                OrderHistoryGrid.ItemsSource = _allOrders;
                return;
            }
            var filtered = _allOrders.Where(o =>
                o.OrderId.ToString().Contains(search) ||
                (o.OrderDate != null && o.OrderDate.ToString().ToLower().Contains(search))
            ).ToList();
            OrderHistoryGrid.ItemsSource = filtered;
        }

        private void OrderSearchClear_Click(object sender, RoutedEventArgs e)
        {
            OrderSearchBox.Text = "";
            OrderHistoryGrid.ItemsSource = _allOrders;
        }

        private void UpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog(_customer);
            if (dialog.ShowDialog() == true)
            {
                using (var db = new LucySalesDataContext())
                {
                    var cust = db.Customers.FirstOrDefault(x => x.CustomerId == _customer.CustomerId);
                    if (cust != null)
                    {
                        cust.CompanyName = dialog.Customer.CompanyName;
                        cust.ContactName = dialog.Customer.ContactName;
                        cust.Phone = dialog.Customer.Phone;
                        cust.Address = dialog.Customer.Address;
                        db.SaveChanges();
                        _customer = cust;
                        LoadCustomerInfo();
                    }
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}