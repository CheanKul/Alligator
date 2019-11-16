using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Alligator.Application.Contract;
using Alligator.Domain.Model;
using Alligator.Persistence;
using Microsoft.Extensions.Configuration;

namespace Alligator.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ILoggingManager loggingManager;
        private IHttpContextAccessor httpContextAccessor;
        private readonly IUserApplication userApp;
        private readonly AppDBContext context;
        private readonly IConfiguration configuration;

        public AuthController(
            ILoggingManager _loggingManager,
            IHttpContextAccessor _httpContextAccessor,
            IUserApplication userApp,
            AppDBContext context,
            IConfiguration configuration)
        {
            this.loggingManager = _loggingManager;
            this.httpContextAccessor = _httpContextAccessor;
            this.userApp = userApp;
            this.context = context;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            return Ok(await userApp.Get(model.Username, model.Password));

            

        }

        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> UserRegistration([FromBody] User model)
        {

            try
            {
                return Ok( await userApp.Create(model));
            }
            catch (System.Exception)
            {

                throw;
            }

        }
            
    }
}