using AutoMapper;
using EcommerceLite.DTOs;

namespace EcommerceLite.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}