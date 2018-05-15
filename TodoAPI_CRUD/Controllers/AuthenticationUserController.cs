using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_CRUD.Migrations;

namespace TodoAPI_CRUD.Controllers
{
    /// <summary>
    /// Manage User's authentication
    /// </summary>

    [Produces("application/json")]
    [Route("api/AuthenticationUser")]
    public class AuthenticationUserController : Controller
    {
        private readonly SignInManager<FichierCentral> _signInManager;
        public AuthenticationUserController(SignInManager<FichierCentral> signInManager)
        {
            _signInManager = signInManager;
        }

        // POST: api/AuthenticationUser
        /// <summary>
        /// Log in a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Status OK if User is Logged In</returns>
        /// <response code="200">If the User is LoggedIn</response>
        /// <response code="400">If the User is null</response>
        /// <response code="404">If the User doesn't exist</response> 

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] FichierCentral user)
        {
            if (user.Login == null || user.Password == null)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return NotFound();
            }

            return Ok();
        }


        /// <summary>
        /// Log out a User
        /// </summary>
        /// <returns>Status Ok when User is logged Out</returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

    }
}
