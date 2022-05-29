using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPILayer.Models.ViewModels;

namespace WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        [HttpGet("/roles/{id}")]
        public async Task<ActionResult<List<string>>> GetRoles(Guid id)
        {
            List<string> roles = new List<string>();
            var user = await _userManager.FindByIdAsync(id.ToString());
            foreach (var item in await _userManager.GetRolesAsync(user))
            {
                roles.Add(item.Trim());
            }
            return roles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, EditUserViewModel user)
        {
            if (id != user.Id)
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


            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());
            appUser.UserName = user.UserName;
            appUser.Email = user.Email;
            appUser.Status = user.Status;


            IdentityResult result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPut("/updatepassword/{id}")]
        public async Task<IActionResult> PutPassword(Guid id, EditPasswordViewModel user)
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

            var appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser == null)
            {
                return NotFound();
            }

            appUser.PasswordHash = _userManager.PasswordHasher.HashPassword(appUser, user.NewPassword);

            IdentityResult result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(CreateUserViewModel appUser)
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

            var user = new AppUser()
            {
                UserName=appUser.UserName,
                Email = appUser.Email,
                Status = true
            };

            var result = await _userManager.CreateAsync(user, appUser.Password);

            if (result.Succeeded)
            {
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user =await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}
