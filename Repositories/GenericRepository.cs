using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoursesWorkshop.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationContext _context;
        private DbSet<T> table;

        public GenericRepository()
        {
            _context = new ApplicationContext();
            table = _context.Set<T>();
        }

        public void Create(T entity)
        {
            table.Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            Save();
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
