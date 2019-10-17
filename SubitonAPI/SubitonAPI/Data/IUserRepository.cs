using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    /// <summary>
    /// Getting data for users, implemernt generic to have add,rmv
    /// </summary>
    public interface IUserRepository: IGenericRepository
    {
        /// <summary>
        /// Gets all users.</summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAllUsers();

        /// <summary>
        /// Gets the user.</summary>
        /// <param name="UserID">The user identifier.</param>
        /// <returns></returns>
        Task<User> GetUser(int UserID);
    }
}
