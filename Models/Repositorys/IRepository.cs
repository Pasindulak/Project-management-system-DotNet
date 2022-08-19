using System.Linq.Expressions;

namespace PMS_Net.Models.Repositorys
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllProjects();
        void Add(T entity);
        void Remove(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    }
}
