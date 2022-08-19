using PMS_Net.Models;

namespace PMS_Net.Repo
{
    public interface IProjectRepository : IRepository<Project>
    {
        bool Update(int id, Project project);
    }

}
