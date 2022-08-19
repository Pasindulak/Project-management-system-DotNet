namespace PMS_Net.Repo
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T Add(T entity);
        public bool Delete(int id);
        public bool Update(T entity);

    }
}
