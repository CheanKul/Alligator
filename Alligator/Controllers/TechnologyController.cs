
using System;
using System.Threading.Tasks;
using Alligator.Application.Contract;
using Alligator.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alligator.Controllers
{
    [Route("api/[Controller]")]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyApplication technologyApp;

        public TechnologyController(ITechnologyApplication technologyApp)
        {
            this.technologyApp = technologyApp;
        }

        [HttpGet]
        [Route("Technologies")]
        public async Task<IActionResult> ListOfTechnologiesAsync()
        {
            try
            {
                return Ok(await technologyApp.GetTechnologiesAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("UpdateTechnology")]
        [Authorize]
        public async Task<IActionResult> UpdateTechnologyAsync([FromForm] TechnologyModel technologyModel)
        {
            try
            {
                return Ok(await technologyApp.UpdateTechnologyAsync(technologyModel));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("TechnologyById")]
        public async Task<IActionResult> GetTechnologyByIdAsync(string Id)
        {
            try
            {
                return Ok(await technologyApp.GetTechnologyByIdAsync(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}