using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;

namespace SmWikipediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddAdministrator([FromBody] AdministratorCreateDto adminDto)
        {
            _accountService.Add(adminDto);
            return Ok();
        }

        [HttpGet("login")]
        public ActionResult Login([FromQuery] LoginDto login)
        {
            string token = _accountService.GenerateJwt(login);
            return Ok(token);
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var admins = _accountService.GetAdmins();
            return Ok(admins);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _accountService.Delete(id);
            return NoContent();
        }
    }
}
