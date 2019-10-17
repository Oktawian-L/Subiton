using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var userData = File.ReadAllText("Data/UserSeed.json");
        }
    }
}
