using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SubitonAPI.Data;
using SubitonAPI.DTO;
using SubitonAPI.Helpers;
using SubitonAPI.Models;

namespace SubitonAPI.Controllers
{
    /// <summary>
    /// Photo uploaded to claudinary
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The claudinary 
        /// </summary>
        private readonly IOptions<ClaudinarySettings> _claudinarySettings;

        /// <summary>
        /// The cloudinary
        /// </summary>
        private readonly Cloudinary _cloudinary;

        public PhotosController(DataContext context, IUserRepository userRepository, IMapper mapper, IOptions<ClaudinarySettings> claudinarySettings)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
            _claudinarySettings = claudinarySettings ?? throw new ArgumentNullException(nameof(claudinarySettings));

            Account account = new Account(
                _claudinarySettings.Value.CloudName,
                _claudinarySettings.Value.ApiKey,
                _claudinarySettings.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        // POST: api/Photos
        [HttpPost]
        public async Task<ActionResult> AddPhotoForUser(int userId, PhotoCreateDTO photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            if (photo == null)
                throw new ArgumentNullException(nameof(photo));

            return CreatedAtAction("GetPhoto", new { id = photo.Id }, photo);
        }


        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        {
            return await _context.Photos.ToListAsync().ConfigureAwait(true);
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {

            if (photo == null)
                throw new ArgumentNullException(nameof(photo));

            if (id != photo.Id)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Photo>> DeletePhoto(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            return photo;
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }
    }
}
