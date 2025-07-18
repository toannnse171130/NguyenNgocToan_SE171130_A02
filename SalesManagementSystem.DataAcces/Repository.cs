using Microsoft.EntityFrameworkCore;
using SalesManagementSystem.DataAcces.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagementSystem.DataAcces
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LucySalesDataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            _context = new LucySalesDataContext();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(object id) => _dbSet.Find(id);

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
