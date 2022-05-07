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
    public class SosialController : ControllerBase
    {
        private readonly ISosialService _sosialService;

        public SosialController(ISosialService sosialService)
        {
            _sosialService = sosialService;
        }
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Sosial>>> Get()
        {
            return await _sosialService.GetAll(x => x.Status == true);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sosial>>> Getsosials()
        {
            return await _sosialService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sosial>> Getsosial(Guid id)
        {
            var sosial = await _sosialService.GetById(id);

            if (sosial == null)
            {
                return NotFound();
            }

            return sosial;
        }


        [HttpPut("{id}")]
        public IActionResult Putsosial(Guid id, Sosial sosial)
        {
            if (id != sosial.Id)
            {
                return BadRequest();
            }


            _sosialService.Update(sosial);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Sosial> Postsosial(Sosial sosial)
        {
            _sosialService.Insert(sosial);

            return CreatedAtAction("Getsosial", new { id = sosial.Id }, sosial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesosial(Guid id)
        {
            var sosial = await _sosialService.GetById(id);
            if (sosial == null)
            {
                return NotFound();
            }

            _sosialService.Delete(sosial);

            return NoContent();
        }
    }
}
