using PMS_Net.Data;

namespace PMS_Net.Models.Repositorys
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _connection;
        public ProjectRepository(AppDbContext connection) : base(connection)
        {
            _connection = connection;
        }

        public void Save()
        {
            _connection.SaveChanges();
        }

        public void Update(Project project)
        {
            var obj = _connection.Project.FirstOrDefault(p => p.Id == project.Id);
            obj.Name = project.Name;
        }
    }
}
