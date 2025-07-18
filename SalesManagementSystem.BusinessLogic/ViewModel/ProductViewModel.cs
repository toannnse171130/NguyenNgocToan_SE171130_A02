using SalesManagementSystem.DataAcces.Models;
using SalesManagementSystem.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SalesManagementSystem.BusinessLogic
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _service;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _allProducts;
        private Product _selectedProduct;
        private string _searchText;
        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel()
        {
            _service = new ProductService();
            _allProducts = new ObservableCollection<Product>(_service.GetAllProducts());
            _products = new ObservableCollection<Product>(_allProducts);
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set { _products = value; OnPropertyChanged(); }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterProducts();
            }
        }

        public void FilterProducts()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Products = new ObservableCollection<Product>(_allProducts);
            }
            else
            {
                Products = new ObservableCollection<Product>(
                    _allProducts.Where(p => p.ProductName != null && p.ProductName.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase))
                );
            }
            OnPropertyChanged(nameof(Products));
        }

        public void AddProduct(Product product)
        {
            var validationResults = ValidationService.Validate(product);
            if (validationResults.Count == 0)
            {
                _service.AddProduct(product);
                Products.Add(product);
            }
            // else: handle validation errors (e.g., show message)
        }

        public void UpdateProduct(Product product)
        {
            var validationResults = ValidationService.Validate(product);
            if (validationResults.Count == 0)
            {
                _service.UpdateProduct(product);
                // Optionally refresh Products collection
            }
            // else: handle validation errors
        }

        public void DeleteProduct(Product product)
        {
            _service.DeleteProduct(product.ProductId);
            Products.Remove(product);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
