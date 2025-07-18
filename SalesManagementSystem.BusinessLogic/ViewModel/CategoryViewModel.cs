using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private readonly CategoryService _service;
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        public event PropertyChangedEventHandler PropertyChanged;

        public CategoryViewModel()
        {
            _service = new CategoryService();
            _categories = new ObservableCollection<Category>(_service.GetAllCategories());
        }

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        public void AddCategory(Category category)
        {
            var validationResults = ValidationService.Validate(category);
            if (validationResults.Count == 0)
            {
                _service.AddCategory(category);
                Categories.Add(category);
            }
            // else: handle validation errors
        }

        public void UpdateCategory(Category category)
        {
            var validationResults = ValidationService.Validate(category);
            if (validationResults.Count == 0)
            {
                _service.UpdateCategory(category);
                // Optionally refresh Categories collection
            }
            // else: handle validation errors
        }

        public void DeleteCategory(Category category)
        {
            _service.DeleteCategory(category.CategoryId);
            Categories.Remove(category);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
