using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubitonAPI.Models;

namespace SubitonAPI.Data
{
    /// <summary>
    /// Authorization repository implementation
    /// </summary>
    /// <seealso cref="SubitonAPI.Data.IAuthRepository" />
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        #region publicMethods

        /// <summary>Initializes a new instance of the <see cref="AuthRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Username == username);

            if (user == null)
                return null;

            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        /// <summary>Registers the specified username.</summary>
        /// <param name="user"></param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            //setting password for user. with random seed
            CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <summary>Users the exists.</summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            else
                return false;
        }

        #endregion publicMethods

        #region privateMethods

        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hMac.Key;

                //get text to byte array
                passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        # endregion privateMethods

    }
}
