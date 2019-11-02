using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubitonAPI.Models;

namespace SubitonAPI.Data
{
    /// <summary></summary>
    /// <seealso cref="SubitonAPI.Data.IGenericRepository" />
    /// <seealso cref="SubitonAPI.Data.IUserRepository" />
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all users.</summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        /// <summary>Gets the user.</summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUser(int UserID)
        {
            var user = await _context.Users.Where(p => p.Id == UserID)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync();

            user.Photos = _context.Photos.Where(x => x.set_user_nrid == user.Id).ToList();

            return user;
        }
    }
}
