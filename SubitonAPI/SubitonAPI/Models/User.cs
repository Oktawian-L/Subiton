using SubitonAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AnimalType AnimalType { get; set; }

        // basic user info
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Rasa { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //additional info
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

        //photo

        public ICollection<Photo> Photos { get; set; }

    }
}
