using Microsoft.EntityFrameworkCore;
using PMS_Net.Data;
using System.Linq.Expressions;

namespace PMS_Net.Models.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _connection;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext connection)
        {
            _connection = connection;
            this.dbSet = connection.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAllProjects()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null) {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
