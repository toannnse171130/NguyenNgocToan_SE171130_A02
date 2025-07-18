using System.Windows;
using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAcces.Models;

namespace SalesManagementSystem.WPF
{
    public partial class CategoryView : Window
    {
        private CategoryViewModel _viewModel;

        public CategoryView()
        {
            InitializeComponent();
            _viewModel = new CategoryViewModel();
            DataContext = _viewModel;
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CategoryDialog(new Category());
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddCategory(dialog.Category);
            }
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCategory != null)
            {
                var categoryCopy = new Category
                {
                    CategoryId = _viewModel.SelectedCategory.CategoryId,
                    CategoryName = _viewModel.SelectedCategory.CategoryName,
                    Description = _viewModel.SelectedCategory.Description
                };
                var dialog = new CategoryDialog(categoryCopy);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateCategory(dialog.Category);
                }
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCategory != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteCategory(_viewModel.SelectedCategory);
                }
            }
        }
    }
}
