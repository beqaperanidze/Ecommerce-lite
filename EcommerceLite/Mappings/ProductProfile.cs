using AutoMapper;
using EcommerceLite.DTOs;
using EcommerceLite.Models;

namespace EcommerceLite.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductCreateDto, Product>();
    }
}