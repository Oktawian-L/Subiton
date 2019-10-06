using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubitonAPI.Models;

namespace SubitonAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

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
        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
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
        # endregion privateMethods

    }
}
