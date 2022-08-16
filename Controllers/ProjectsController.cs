using Microsoft.AspNetCore.Mvc;
using PMS_Net.Models;
using PMS_Net.Repo;

namespace PMS_Net.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectsController : ControllerBase
    {
        private ProjectRepo _ProjectRepo;
        public ProjectsController(ProjectRepo _ProjectRepo)
        {
            this._ProjectRepo = _ProjectRepo;

        }

        [HttpGet]
        public ActionResult<List<Project>> getProjects()
        {
            return _ProjectRepo.getProjects();
        }

        [HttpPost("{name}")]
        public ActionResult createProject(string name)
        {
            _ProjectRepo.createProject(new Project { Name = name });
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProject(int id)
        {
            if (_ProjectRepo.deleteProject(id))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id},{name}")]
        public ActionResult updateProject(int id, string name)
        {
            if (_ProjectRepo.updateProject(id, new Project { Id = id, Name = name }))
                return Ok();
            return BadRequest();
        }
    }
}
