using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Data
{
    public interface IAuthRepository
    {
        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<User> Login(string username, string password);

        /// <summary>Registers the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<User> Register(User user, string password);

        /// <summary>Users the exists.</summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        Task<bool> UserExists(string username);
    }
}
