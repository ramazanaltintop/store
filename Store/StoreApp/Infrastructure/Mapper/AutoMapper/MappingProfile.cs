using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
            
            CreateMap<RoleDtoForInsertion, IdentityRole>();
            CreateMap<RoleDtoForUpdate, IdentityRole>().ReverseMap();
        }
    }
}