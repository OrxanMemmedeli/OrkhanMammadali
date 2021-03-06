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
    public class CVDocumentController : ControllerBase
    {
        private readonly ICVDocumentService _cVDocumentService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CVDocumentController(ICVDocumentService cVDocumentService, IWebHostEnvironment hostEnvironment)
        {
            _cVDocumentService = cVDocumentService;
            _hostEnvironment = hostEnvironment;
        }

        private void UploadFile(CVDocument model)
        {
            string wwwRootPath = _hostEnvironment.ContentRootPath;
            string extension = Path.GetExtension(model.File.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadFiles");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.fileURL = Path.Combine(path, newImageName);
                model.File.CopyTo(fileStream);
            }

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CVDocument>>> GetcVDocuments()
        {
            return await _cVDocumentService.GetAll();
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CVDocument>>> Get()
        {
            return await _cVDocumentService.GetAll(x => x.Status == true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CVDocument>> GetcVDocument(Guid id)
        {
            var cVDocument = await _cVDocumentService.GetById(id);

            if (cVDocument == null)
            {
                return NotFound();
            }

            return cVDocument;
        }


        [HttpPut("{id}")]
        public IActionResult PutcVDocument(Guid id, CVDocument cVDocument)
        {
            if (id != cVDocument.Id)
            {
                return BadRequest();
            }


            _cVDocumentService.Update(cVDocument);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<CVDocument> PostcVDocument(CVDocument cVDocument)
        {
            if (cVDocument.File != null)
            {
                UploadFile(cVDocument);
            }
            _cVDocumentService.Insert(cVDocument);

            return CreatedAtAction("GetcVDocument", new { id = cVDocument.Id }, cVDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecVDocument(Guid id)
        {
            var cVDocument = await _cVDocumentService.GetById(id);
            if (cVDocument == null)
            {
                return NotFound();
            }

            _cVDocumentService.Delete(cVDocument);

            return NoContent();
        }
    }
}
