using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.DTO
{
    /// <summary>
    /// Base user
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 12 signs.")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    /// <summary>
    /// User data ata to show profile\</summary>
    /// <seealso cref="SubitonAPI.DTO.UserDTO" />
    public class UserForListDto: UserDTO
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Rasa { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }

    /// <summary>
    /// User data ata to show profile\</summary>
    /// </summary>
    /// <seealso cref="SubitonAPI.DTO.UserDTO" />
    public class UserForDetailsDTO : UserForListDto
    {
        public string Height { get; set; }
        public string FurColor { get; set; }
        public string Weight { get; set; }
        public string Nature { get; set; }
        public string MartialStatus { get; set; }

        //description
        public string Description { get; set; }
        public string LookingFor { get; set; }

        // Upodobania
        public string Interests { get; set; }
        public string FreeTimeActivities { get; set; }
        public string Education { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class UserRegisterDTO : UserDTO
    {

    }
}
