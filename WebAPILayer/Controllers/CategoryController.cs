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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Getcategorys()
        {
            return await _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Getcategory(Guid id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }


        [HttpPut("{id}")]
        public IActionResult Putcategory(Guid id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }


            _categoryService.Update(category);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Category> Postcategory(Category category)
        {
            _categoryService.Insert(category);

            return CreatedAtAction("Getcategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategory(Guid id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Delete(category);

            return NoContent();
        }
    }
}
