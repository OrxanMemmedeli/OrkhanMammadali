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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            return await _customerService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Getcustomer(Guid id)
        {
            var customer = await _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }


        [HttpPut("{id}")]
        public IActionResult Putcustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }


            _customerService.Update(customer);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Customer> Postcustomer(Customer customer)
        {
            _customerService.Insert(customer);

            return CreatedAtAction("Getcustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(Guid id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Delete(customer);

            return NoContent();
        }
    }
}
