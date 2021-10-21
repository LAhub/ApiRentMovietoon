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
            CreateMap<Gener,GeneroDTO>().ReverseMap();
            CreateMap<GenerCreateDTO, Gener >();
            CreateMap<IdentityUser, UserDTO>();
            CreateMap<Rent, RentDTO>().ReverseMap();
        }
    }
}
