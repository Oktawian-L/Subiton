using Microsoft.AspNetCore.Mvc;
using SubitonAPI.Data;
using SubitonAPI.DTO;
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
        public async Task<ActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            userRegisterDTO.Username = userRegisterDTO.Username.ToLower();
            if (await _repository.UserExists(userRegisterDTO.Username))
            {
                return BadRequest("User already exixts");
            }

            var userToCreate = new User
            {
                Username = userRegisterDTO.Username
            };

            await _repository.Register(userToCreate, userRegisterDTO.Password);

            return StatusCode(201);
        }
    }
}
