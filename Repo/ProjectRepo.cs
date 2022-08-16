﻿using Newtonsoft.Json;
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

        public void createProject(Project project)
        {
            project.Id = _projectList.Count + 1;
            _projectList.Add(project);
        }

        public void deleteProject(int id)
        {
            int index = _projectList.FindIndex(project => project.Id == id);
            if (index != -1)
                _projectList.RemoveAt(index);
        }

        public void updateProject(int id, Project project)
        {
            int index = _projectList.FindIndex(p => p.Id == id);
            if (index != -1)
                _projectList[index] = project;
        }
    }
}
