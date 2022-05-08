using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly IProfilService _profilService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfilController(IProfilService profilService, IWebHostEnvironment hostEnvironment)
        {
            _profilService = profilService;
            _hostEnvironment = hostEnvironment;
        }

        private void UploadFile(Profil model)
        {
            string wwwRootPath = _hostEnvironment.ContentRootPath;
            string extension = Path.GetExtension(model.File.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadFiles");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.LogoURL = Path.Combine(path, newImageName);
                model.File.CopyTo(fileStream);
            }

        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Profil>>> Get()
        {
            return await _profilService.GetAll(x => x.Status == true);
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
            if (profil.File != null)
            {
                UploadFile(profil);
            }

            _profilService.Update(profil);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Profil> Postprofil(Profil profil)
        {
            if (profil.File != null)
            {
                UploadFile(profil);
            }

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
