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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Skill>>> Get()
        {
            return await _skillService.GetAllTrue(x => x.Status == true);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> Getskills()
        {
            return await _skillService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> Getskill(Guid id)
        {
            var skill = await _skillService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }


        [HttpPut("{id}")]
        public IActionResult Putskill(Guid id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }


            _skillService.Update(skill);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Skill> Postskill(Skill skill)
        {
            _skillService.Insert(skill);

            return CreatedAtAction("Getskill", new { id = skill.Id }, skill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteskill(Guid id)
        {
            var skill = await _skillService.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }

            _skillService.Delete(skill);

            return NoContent();
        }
    }
}
