using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SubitonAPI.Data;
using SubitonAPI.DTO;
using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SubitonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllercs : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthControllercs(IAuthRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
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
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserDTO userDTO)
        {
            var user = await _repository.Login(userDTO.Username.ToLower(),userDTO.Password);
            if (user == null)
                return Unauthorized();

            //JWT
            var jwtToken = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            return StatusCode(201);
        }
    }
}
