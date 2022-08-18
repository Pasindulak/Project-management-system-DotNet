using PMS_Net.Models;

namespace PMS_Net.Repo
{
    public interface IProjectRepo
    {
        public List<Project> getAll();
        public int create(Project project);
        public bool delete(int id);
        public bool update(int id, Project project);

    }
}
