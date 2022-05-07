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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Education>>> Get()
        {
            return await _educationService.GetAll(x => x.Status == true);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> Geteducations()
        {
            return await _educationService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> Geteducation(Guid id)
        {
            var education = await _educationService.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            return education;
        }


        [HttpPut("{id}")]
        public IActionResult Puteducation(Guid id, Education education)
        {
            if (id != education.Id)
            {
                return BadRequest();
            }


            _educationService.Update(education);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Education> Posteducation(Education education)
        {
            _educationService.Insert(education);

            return CreatedAtAction("Geteducation", new { id = education.Id }, education);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteeducation(Guid id)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return NotFound();
            }

            _educationService.Delete(education);

            return NoContent();
        }
    }
}
