using System.Collections.Generic;

namespace SalesManagementSystem.DataAcces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save();
    }
}
