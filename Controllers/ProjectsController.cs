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
    }
}
