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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Getcontacts()
        {
            return await _contactService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Getcontact(Guid id)
        {
            var contact = await _contactService.GetById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }


        [HttpPut("{id}")]
        public IActionResult Putcontact(Guid id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }


            _contactService.Update(contact);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Contact> Postcontact(Contact contact)
        {
            _contactService.Insert(contact);

            return CreatedAtAction("Getcontact", new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecontact(Guid id)
        {
            var contact = await _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Delete(contact);

            return NoContent();
        }
    }
}
