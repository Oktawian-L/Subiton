using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    /// <summary>
    /// Generic repo to operate on database
    /// </summary>
    /// <seealso cref="SubitonAPI.Data.IGenericRepository" />
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /// <summary>
        /// Saves all.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
