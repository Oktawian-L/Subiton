using AutoMapper;
using SubitonAPI.DTO;
using SubitonAPI.Helpers;
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
            //custom profile to select main photo
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age, opt => {
                    opt.MapFrom((src, d) => src.DateOfBirth.CalculateAge());
                });

            // opening profile data
            CreateMap<User, UserForDetailsDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age, opt => {
                    opt.MapFrom((src, d) => src.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotoDTO>();
            CreateMap<PhotoDTO, Photo>();
        }
    }
}
