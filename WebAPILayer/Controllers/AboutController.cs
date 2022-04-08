using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Contrete.Context;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<About>>> GetAbouts()
        {
            return await _aboutService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<About>> GetAbout(Guid id)
        {
            var about = await _aboutService.GetById(id);

            if (about == null)
            {
                return NotFound();
            }

            return about;
        }


        [HttpPut("{id}")]
        public IActionResult PutAbout(Guid id, About about)
        {
            if (id != about.Id)
            {
                return BadRequest();
            }


            _aboutService.Update(about);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<About> PostAbout(About about)
        {
            _aboutService.Insert(about);

            return CreatedAtAction("GetAbout", new { id = about.Id }, about);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var about = await _aboutService.GetById(id);
            if (about == null)
            {
                return NotFound();
            }

            _aboutService.Delete(about);

            return NoContent();
        }

    }
}
