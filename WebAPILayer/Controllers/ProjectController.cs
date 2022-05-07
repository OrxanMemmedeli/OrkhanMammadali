using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await _projectService.GetAll(x => x.Status == true);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Getprojects()
        {
            return await _projectService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Getproject(Guid id)
        {
            var project = await _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }


        [HttpPut("{id}")]
        public IActionResult Putproject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }


            _projectService.Update(project);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Project> Postproject(Project project)
        {
            _projectService.Insert(project);

            return CreatedAtAction("Getproject", new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproject(Guid id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectService.Delete(project);

            return NoContent();
        }
    }
}
