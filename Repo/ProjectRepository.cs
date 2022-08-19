using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMS_Net.Data;
using PMS_Net.Models;

namespace PMS_Net.Repo
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {

        }

        public bool Update(int id, Project project)
        {
           project.Id = id;
           return base.Update(project);
        }

    }
}
