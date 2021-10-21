using ApiRentMovietoon.DTOs;
using ApiRentMovietoon.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiRentMovietoon.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<Gender,GenderDTO>().ReverseMap();
            CreateMap<GenderCreateDTO, Gender >();
            CreateMap<IdentityUser, UserDTO>();
            CreateMap<Rent, RentDTO>().ReverseMap();
        }
    }
}
