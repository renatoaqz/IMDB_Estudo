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
    public class VoteController : ControllerBase
    {
        private IVoteBusiness _voteBusiness;
        public VoteController(IVoteBusiness voteBusiness)
        {
            _voteBusiness = voteBusiness;
        }

        [HttpGet]
        [Authorize("user")]
        public IActionResult Get()
        {
            var votes = _voteBusiness.FindAllFull();

            if (votes != null)
                return Ok(votes);
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("/v{version:apiVersion}/GetTopRatedMoviesOrderByMovieTitleCountVotes")]
        [Authorize("user")]
        public IActionResult GetTopMoviesByCountVotes()
        {
            var movies = _voteBusiness.GetTopRatedMoviesOrderByMovieTitleCountVotes();

            if (movies != null)
                return Ok(movies);
            else
                return NotFound();
        }

        [HttpPost]
        [Authorize("user")]
        public IActionResult Post([FromBody] Vote vote)
        {
            if (vote != null)
                return Ok(_voteBusiness.Create(vote));
            else
                return BadRequest();
        }
    }
}
