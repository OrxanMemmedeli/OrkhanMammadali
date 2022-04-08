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
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>> GetAdresses()
        {
            return await _adressService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdress(Guid id)
        {
            var adress = await _adressService.GetById(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }


        [HttpPut("{id}")]
        public IActionResult PutAdress(Guid id, Adress adress)
        {
            if (id != adress.Id)
            {
                return BadRequest();
            }


            _adressService.Update(adress);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Adress> PostAdress(Adress adress)
        {
            _adressService.Insert(adress);

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(Guid id)
        {
            var adress = await _adressService.GetById(id);
            if (adress == null)
            {
                return NotFound();
            }

            _adressService.Delete(adress);

            return NoContent();
        }
    }
}
