using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserRegisterDTO : UserDTO
    {

    }
}
