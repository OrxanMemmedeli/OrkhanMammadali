using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPILayer.Models.ViewModels;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppRole>>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppRole>> GetRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(Guid id, RoleViewModel role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(errors);
            }


            AppRole AppRole = await _roleManager.FindByIdAsync(id.ToString());
            AppRole.Name = role.Name;

            IdentityResult result = await _roleManager.UpdateAsync(AppRole);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<AppRole>> PostUser(RoleViewModel appRole)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(errors);
            }

            var role = new AppRole()
            {
                Name=appRole.Name
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return CreatedAtAction("GetRole", new { id = role.Id }, role);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}
