using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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
    public class ProfilController : ControllerBase
    {
        private readonly IProfilService _profilService;

        public ProfilController(IProfilService profilService)
        {
            _profilService = profilService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profil>>> Getprofils()
        {
            return await _profilService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profil>> Getprofil(Guid id)
        {
            var profil = await _profilService.GetById(id);

            if (profil == null)
            {
                return NotFound();
            }

            return profil;
        }


        [HttpPut("{id}")]
        public IActionResult Putprofil(Guid id, Profil profil)
        {
            if (id != profil.Id)
            {
                return BadRequest();
            }


            _profilService.Update(profil);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Profil> Postprofil(Profil profil)
        {
            _profilService.Insert(profil);

            return CreatedAtAction("Getprofil", new { id = profil.Id }, profil);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprofil(Guid id)
        {
            var profil = await _profilService.GetById(id);
            if (profil == null)
            {
                return NotFound();
            }

            _profilService.Delete(profil);

            return NoContent();
        }
    }
}
