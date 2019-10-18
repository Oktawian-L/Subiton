using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 12 signs.")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
    public class UserRegisterDTO : UserDTO
    {

    }
    public class UserForListDto: UserDTO
    {

    }
}
