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
    // data to show profile
    public class UserForListDto: UserDTO
    {
        public int Id { get; set; }

        // basic user info
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Rasa { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
