using Microsoft.AspNetCore.Mvc;

namespace PMS_Net.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private string data;
        public ProjectController()
        {
            data = System.IO.File.ReadAllText("projects.json");

        }

        [HttpGet]
        public ActionResult<string> getProjects()
        {
            return data;
        }
    }
}
