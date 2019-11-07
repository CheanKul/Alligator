using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Alligator.Application.Contract;
using Alligator.Domain.Model;
using Alligator.Persistence;

namespace Alligator.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ILoggingManager loggingManager;
        private IHttpContextAccessor httpContextAccessor;
        private readonly IUserApplication userApp;
        private readonly AppDBContext context;

        public AuthController(
            ILoggingManager _loggingManager,
            IHttpContextAccessor _httpContextAccessor,
            IUserApplication userApp,
            AppDBContext context)
        {
            this.loggingManager = _loggingManager;
            this.httpContextAccessor = _httpContextAccessor;
            this.userApp = userApp;
            this.context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var book = userApp.Get(model.Username, model.Password);

            if (book == null)
            {
                return Unauthorized();
            }

            var claims = new[] {
                new Claim (JwtRegisteredClaimNames.Sub, model.Username),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };

            var signitureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyAdvanceSupperKey"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(2),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signitureKey, SecurityAlgorithms.HmacSha256)

            );
            return Ok(new
            {
                Authenticated = true,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });

        }

        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> UserRegistration([FromBody] User model)
        {

            try
            {
                userApp.Create(model);
                return CreatedAtRoute("GetBook", new { id = model.Id.ToString() }, model);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<KnackbeUser>> Get() =>
            context.KnackbeUsers.ToList();
    }
}