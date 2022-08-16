using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMS_Net.Models;

namespace PMS_Net.Repo
{
    public class ProjectRepo
    {
        private List<Project> _projectList;
        public ProjectRepo()
        {
            string data = System.IO.File.ReadAllText("projects.json");
            JToken jObject = JObject.Parse(data);
            jObject = jObject["projects"];
            System.Console.WriteLine(jObject.ToString());
            _projectList = JsonConvert.DeserializeObject<List<Project>>(jObject.ToString());
        }
        public List<Project> getProjects()
        {
            return _projectList;
        }

        public void addProject(Project project)
        {

        }

        public void deleteProject(int id)
        {

        }

        public void updateProject(int id, Project project)
        {

        }
    }
}
