using Microsoft.AspNetCore.Mvc;
using SubitonAPI.Data;
using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllercs : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthControllercs(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(string username, string password)
        {
            username = username.ToLower();
            if (await _repository.UserExists(username))
            {
                return BadRequest("User already exixts");
            }

            var userToCreate = new User
            {
                Username = username
            };

            await _repository.Register(userToCreate, password);

            return StatusCode(201);
        }
    }
}
