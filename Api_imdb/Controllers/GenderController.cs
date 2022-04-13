using Api_imdb.Business;
using Api_imdb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GenderController : Controller
    {
        private IGenderBusiness _classicBusiness;
        public GenderController(IGenderBusiness classicBusiness)
        {
            _classicBusiness = classicBusiness;
        }

        [HttpGet]
        [Authorize("admin")]
        public IActionResult Get()
        {
            return Ok(_classicBusiness.FindAll());
        }
        [HttpPost]
        [Authorize("admin")]
        public IActionResult Post([FromBody] Gender classic)
        {
            if (classic != null)
                return Ok(_classicBusiness.Create(classic));
            else
                return BadRequest();
        }
    }
}
