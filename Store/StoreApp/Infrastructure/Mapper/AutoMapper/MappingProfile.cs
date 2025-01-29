using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace StoreApp.Infrastructure.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }
    }
}