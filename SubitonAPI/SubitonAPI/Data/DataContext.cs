using Microsoft.EntityFrameworkCore;
using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region TableDefinitions
        public DbSet<Values> Values { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion TableDefinitions
    }
}
