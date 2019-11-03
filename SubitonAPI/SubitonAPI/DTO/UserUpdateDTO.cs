using SubitonAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.DTO
{

    /// <summary>
    /// DTO to get data from front-end
    /// </summary>
    public class UserUpdateDTO
    {
        public AnimalType AnimalType { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Rasa { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; } 
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
    }
}
