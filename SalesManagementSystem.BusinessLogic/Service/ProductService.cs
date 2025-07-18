using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService()
        {
            _productRepository = new Repository<Product>();
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();

        public Product GetProductById(int id) => _productRepository.GetById(id);

        public void AddProduct(Product product)
        {
            _productRepository.Insert(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
