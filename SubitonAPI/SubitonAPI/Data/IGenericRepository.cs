using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    /// <summary>
    /// Generic repo
    /// </summary>
    public interface IGenericRepository
    {
        /// <summary>Adds the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        void Add<T>(T entity) where T : class;

        /// <summary>Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        void Delete<T>(T entity) where T : class;

        /// <summary> 
        /// Saves all.
        /// summary>
        /// <returns></returns>
        Task<bool> SaveAll();
    }
}
