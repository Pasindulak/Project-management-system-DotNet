﻿using Microsoft.AspNetCore.Mvc;
using PMS_Net.Models;
using PMS_Net.Repo;

namespace PMS_Net.Controllers
{
    [ApiController]
    [Route("api/projects")]
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

        [HttpPost]
        public ActionResult createProject(Project project)
        {
            _ProjectRepo.createProject(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProject(int id)
        {
            if (_ProjectRepo.deleteProject(id))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult updateProject(int id, Project project)
        {
            if (_ProjectRepo.updateProject(id, project))
                return Ok();
            return BadRequest();
        }
    }
}
