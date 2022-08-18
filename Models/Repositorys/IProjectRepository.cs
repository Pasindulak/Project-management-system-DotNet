namespace PMS_Net.Models.Repositorys
{
    public interface IProjectRepository : IRepository<Project>  
    {
        void Update(Project project);
        void Save();

    }
}
