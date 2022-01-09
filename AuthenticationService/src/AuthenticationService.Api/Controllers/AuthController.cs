using AuthenticationService.Api.Helper;
using AuthenticationService.Core.Interfaces.Services;
using AuthenticationService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> Login(LoginDto user)
        {
            if (user == null || user.Username == null || user.Password == null)
            {
                return BadRequest();
            }
            // Get user
            var responeUser = await _authService.Login(user.Username).ConfigureAwait(false);
            if (responeUser == null)
            {
                return Ok(new { message = "Invalid username" });
            }
            // Check password hashed by Bcrypt
            /*if (!BCrypt.Net.BCrypt.Verify(user.Password, responeUser.Password))
            {
                return Ok(new { message = "Invalid Password" });
            }*/
            if (responeUser.Password != user.Password)
            {
                return Ok(new { message = "Invalid Password" });
            }
            string jwt = JwtService.Generate(responeUser.Id);
            // Set jwt to Cookies
            HttpContext.Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.Now.AddMinutes(60),
                IsEssential = true
            });
            return Ok(new
            {
                user = responeUser,
                jwt
            });

        }
    }
}
