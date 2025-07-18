using SalesManagementSystem.DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class ReportService
    {
        private readonly LucySalesDataContext _context;

        public ReportService()
        {
            _context = new LucySalesDataContext();
        }

        public IEnumerable<Order> GetOrdersByPeriod(DateTime startDate, DateTime endDate)
        {
            return _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public decimal GetTotalSalesByPeriod(DateTime startDate, DateTime endDate)
        {
            return _context.OrderDetails
                .Where(od => od.Order.OrderDate >= startDate && od.Order.OrderDate <= endDate)
                .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount));
        }
    }
}
