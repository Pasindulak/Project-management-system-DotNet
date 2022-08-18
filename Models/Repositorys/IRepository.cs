using System.Linq.Expressions;

namespace PMS_Net.Models.Repositorys
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllProjects();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>>? filter = null);
    }
}
