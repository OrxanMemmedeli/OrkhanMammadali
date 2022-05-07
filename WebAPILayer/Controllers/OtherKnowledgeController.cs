using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherKnowledgeController : ControllerBase
    {
        private readonly IOtherKnowledgeService _otherKnowledgeService;

        public OtherKnowledgeController(IOtherKnowledgeService otherKnowledgeService)
        {
            _otherKnowledgeService = otherKnowledgeService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OtherKnowledge>>> Get()
        {
            return await _otherKnowledgeService.GetAll(x => x.Status == true);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherKnowledge>>> GetotherKnowledges()
        {
            return await _otherKnowledgeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OtherKnowledge>> GetotherKnowledge(Guid id)
        {
            var otherKnowledge = await _otherKnowledgeService.GetById(id);

            if (otherKnowledge == null)
            {
                return NotFound();
            }

            return otherKnowledge;
        }


        [HttpPut("{id}")]
        public IActionResult PutotherKnowledge(Guid id, OtherKnowledge otherKnowledge)
        {
            if (id != otherKnowledge.Id)
            {
                return BadRequest();
            }


            _otherKnowledgeService.Update(otherKnowledge);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<OtherKnowledge> PostotherKnowledge(OtherKnowledge otherKnowledge)
        {
            _otherKnowledgeService.Insert(otherKnowledge);

            return CreatedAtAction("GetotherKnowledge", new { id = otherKnowledge.Id }, otherKnowledge);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteotherKnowledge(Guid id)
        {
            var otherKnowledge = await _otherKnowledgeService.GetById(id);
            if (otherKnowledge == null)
            {
                return NotFound();
            }

            _otherKnowledgeService.Delete(otherKnowledge);

            return NoContent();
        }
    }
}
