using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubitonAPI.Data;
using SubitonAPI.DTO;
using SubitonAPI.Models;

namespace SubitonAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers().ConfigureAwait(false);
            // map from user to copllection dto
            var usersToReturn = _mapper.Map<IEnumerable<UserForDetailsDTO>>(users);

            return Ok(usersToReturn);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }
            var userToreturn = _mapper.Map<UserForDetailsDTO>(user);
            return Ok(userToreturn);
        }

        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDTO userUpdate)
        {
           /* if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }*/
            var userFromRepo = await _userRepository.GetUser(id);

            _mapper.Map(userUpdate, userFromRepo);

            try
            {
                var result = await _userRepository.SaveAll();
                if (result)
                    return NoContent();
                else
                    throw new Exception($"Canot save a user data");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userRepository.GetUser(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }
        /*
        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _userRepository.Users.Add(user);
            await _userRepository.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userRepository.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Users.Remove(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _userRepository.Users.Any(e => e.Id == id);
        }*/
    }
}