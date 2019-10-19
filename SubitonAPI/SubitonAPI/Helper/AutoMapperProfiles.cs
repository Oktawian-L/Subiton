using AutoMapper;
using SubitonAPI.DTO;
using SubitonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Helper
{
    /// <summary>
    /// How to map from DTO and models
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
        }
    }
}
