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

        public async Task<User> Login(string username, string password)
        {
            var user = new User();
            //var user = await _context.Users.FirstOrDefault();
            if (user == null)
                return null;
            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
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

        private bool VerifyPasswordHash(string password, object passwordHash, object passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {

                }
            }
            return true;
        }

        # endregion privateMethods

    }
}
