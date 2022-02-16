using System.Collections.Generic;

namespace CoursesWorkshop.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Save();

    }
}
