using Api_imdb.Business;
using Api_imdb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_imdb.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MovieController : Controller
    {
        private IMovieBusiness _movieBusiness;
        public MovieController(IMovieBusiness movieBusiness)
        {
            _movieBusiness = movieBusiness;
        }

        [HttpGet]
        [Authorize("admin")]
        //[AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_movieBusiness.FindAllFull());
        }

        [HttpGet]
        [Route("/v{version:apiVersion}/GetByAuthorOrTitleOrGender")]
        public IActionResult GetByAuthorOrTitleOrGender(string title, string author, string gender)
        {
            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(author) || !string.IsNullOrEmpty(gender))
            {
                return Ok(_movieBusiness.FindByAuthorOrTitleOrGender(title,author,gender));
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize("admin")]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (movie != null)
                return Ok(_movieBusiness.Create(movie));
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("/v{version:apiVersion}/GetMoviesOrderByMovieTitleAvgVotes")]
        [Authorize("admin")]
        //[AllowAnonymous]
        public IActionResult GetMoviesOrderByMovieTitleAvgVotes()
        {
            var list = _movieBusiness.GetMoviesOrderByMovieTitleAvgVotes();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();

            }
        }
    }
}
