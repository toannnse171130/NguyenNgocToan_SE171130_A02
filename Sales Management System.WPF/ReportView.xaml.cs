using System;
using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.WPF
{
    public partial class ReportView : Window
    {
        private readonly ReportService _reportService;

        public ReportView()
        {
            InitializeComponent();
            _reportService = new ReportService();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            var startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            var endDate = EndDatePicker.SelectedDate ?? DateTime.MaxValue;
            var orders = _reportService.GetOrdersByPeriod(startDate, endDate);
            OrdersDataGrid.ItemsSource = orders;
            var totalSales = _reportService.GetTotalSalesByPeriod(startDate, endDate);
            TotalSalesText.Text = $"Total Sales: {totalSales:C}";
        }
    }
}
