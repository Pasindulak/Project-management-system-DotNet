using Microsoft.EntityFrameworkCore;
using PMS_Net.Data;
using System.Linq.Expressions;

namespace PMS_Net.Models.Repositorys
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _connection;
        internal DbSet<TEntity> dbSet;
        public Repository(AppDbContext connection)
        {
            _connection = connection;
            this.dbSet = connection.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<TEntity> GetAllProjects()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = dbSet;
            if(filter != null) {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
