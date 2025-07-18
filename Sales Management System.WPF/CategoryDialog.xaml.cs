using System.Windows;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class CategoryDialog : Window
    {
        public Category Category { get; private set; }

        public CategoryDialog(Category category)
        {
            InitializeComponent();
            Category = category;
            DataContext = Category;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
