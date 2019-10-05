using Microsoft.EntityFrameworkCore;
using SubitonBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonBackend.Data
{
    /// <summary></summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {

        }

        #region TableDefinition

        /// <summary>Gets or sets the values.</summary>
        /// <value>The values.</value>
        public DbSet<Value> Values { get; set; }

        #endregion TableDefinition
    }
}
