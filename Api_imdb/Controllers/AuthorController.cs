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
    public class AuthorController : Controller
    {
        private IAuthorBusiness _authorBusiness;
        public AuthorController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        [HttpGet]
        [Authorize("admin")]
        public IActionResult Get()
        {
            return Ok(_authorBusiness.FindAll());
        }
        [HttpPost]
        [Authorize("admin")]
        public IActionResult Post([FromBody] Author author)
        {
            if (author != null)
                return Ok(_authorBusiness.Create(author));
            else
                return BadRequest();
        }
    }
}
