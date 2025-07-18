using SalesManagementSystem.DataAcces;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;

namespace SalesManagementSystem.BusinessLogic
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new Repository<Category>();
        }

        public IEnumerable<Category> GetAllCategories() => _categoryRepository.GetAll();

        public Category GetCategoryById(int id) => _categoryRepository.GetById(id);

        public void AddCategory(Category category)
        {
            _categoryRepository.Insert(category);
            _categoryRepository.Save();
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            _categoryRepository.Save();
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
        }
    }
}
