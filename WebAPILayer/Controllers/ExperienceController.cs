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
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Experience>>> Get()
        {
            return await _experienceService.GetAll(x => x.Status == true);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> Getexperiences()
        {
            return await _experienceService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> Getexperience(Guid id)
        {
            var experience = await _experienceService.GetById(id);

            if (experience == null)
            {
                return NotFound();
            }

            return experience;
        }


        [HttpPut("{id}")]
        public IActionResult Putexperience(Guid id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }


            _experienceService.Update(experience);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Experience> Postexperience(Experience experience)
        {
            _experienceService.Insert(experience);

            return CreatedAtAction("Getexperience", new { id = experience.Id }, experience);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteexperience(Guid id)
        {
            var experience = await _experienceService.GetById(id);
            if (experience == null)
            {
                return NotFound();
            }

            _experienceService.Delete(experience);

            return NoContent();
        }
    }
}
