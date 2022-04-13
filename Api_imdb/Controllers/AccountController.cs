using Api_imdb.Business;
using Api_imdb.DTO;
using Api_imdb.Models;
using Api_imdb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_imdb.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AccountController : Controller
    {

        private IUserService _userService;
        private IUserBusiness _userBusiness;
        public AccountController(IUserService userService, IUserBusiness userBusiness)
        {
            _userService = userService;
            _userBusiness = userBusiness;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("/v{version:apiVersion}/Authenticate")]
        public IActionResult Authenticate([FromBody] UserDTO model)
        {
            try
            {
                var user = _userService.Authenticate(model.Login, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });



                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/v{version:apiVersion}/AddUser")]
        [Authorize("admin")]
        public IActionResult AddUser([FromBody] User model)
        {
            if (model != null)
                return Ok(_userBusiness.Create(model));
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("/v{version:apiVersion}/EditAdmin")]
        [Authorize("admin")]
        public IActionResult EditAdmin([FromBody] User model)
        {
            if (model != null)
                return Ok(_userBusiness.Create(model));
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("/v{version:apiVersion}/EditUser")]
        [Authorize("user")]
        public IActionResult EditUser([FromBody] User model)
        {
            if (model != null)
                return Ok(_userBusiness.Create(model));
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("/v{version:apiVersion}/DeleteUser")]
        [Authorize("admin")]
        public IActionResult DeleteUser(int id)
        {
            if (id != 0)
            {
                User user = _userBusiness.FindByID(id);

                if(user != null)
                {
                    user.Ativo = false;
                    return Ok(_userBusiness.Update(user));
                }
                else
                {
                    return BadRequest();
                }
                
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/v{version:apiVersion}/GetUsersActives")]
        [Authorize("admin")]
        public IActionResult GetUsersActives()
        {
            return Ok(_userBusiness.GetUsersActives());
        }
    }
}
