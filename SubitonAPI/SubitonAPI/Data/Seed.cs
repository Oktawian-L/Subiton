using Newtonsoft.Json;
using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seeds the users.
        /// </summary>
        public void SeedUsers() 
        {
            //add only if empty, new db
            if (!_context.Users.Any())
            {
                var userData = File.ReadAllText("Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHashSalt("password", out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();

                    _context.Users.Add(user);
                }
                _context.SaveChanges();
            }
        }

        /// <summary>Creates the password hash salt.</summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hMac.Key;

                passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
