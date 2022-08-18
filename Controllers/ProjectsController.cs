using Microsoft.AspNetCore.Mvc;
using PMS_Net.Models;
using PMS_Net.Repo;

namespace PMS_Net.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private IProjectRepo _ProjectRepo;
        public ProjectsController(IProjectRepo _ProjectRepo)
        {
            this._ProjectRepo = _ProjectRepo;

        }

        [HttpGet]
        public ActionResult<List<Project>> getProjects()
        {
            return _ProjectRepo.getAll();
        }

        [HttpPost]
        public ActionResult<Dictionary<string, int>> createProject(Project project)
        {
            int id = _ProjectRepo.create(project);
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("id", id);
            return result;
            
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProject(int id)
        {
            if (_ProjectRepo.delete(id))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult updateProject(int id, Project project)
        {
            if (_ProjectRepo.update(id, project))
                return Ok();
            return BadRequest();
        }
    }
}
