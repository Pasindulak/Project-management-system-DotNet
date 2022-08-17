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
            //Read local JSON file and initiate project list
            string data = System.IO.File.ReadAllText("projects.json");
            JToken jObject = JObject.Parse(data);
            jObject = jObject["projects"];
            _projectList = JsonConvert.DeserializeObject<List<Project>>(jObject.ToString());
        }
        public List<Project> getAll()
        {
            return _projectList;
        }

        public int create(Project project)
        {
            project.Id = _projectList.Count + 1;
            _projectList.Add(project);
            return project.Id;
        }

        public bool delete(int id)
        {
            int index = _projectList.FindIndex(project => project.Id == id);
            if (index != -1)
            {
                _projectList.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool update(int id, Project project)
        {
            project.Id =id;
            int index = _projectList.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                _projectList[index] = project;
                return true;
            }
            return false;
        }
    }
}
