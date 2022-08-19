using Microsoft.EntityFrameworkCore;
using PMS_Net.Data;

namespace PMS_Net.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            T? entity = _context.Find<T>(id);
            if (entity == null)
                return false;
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
