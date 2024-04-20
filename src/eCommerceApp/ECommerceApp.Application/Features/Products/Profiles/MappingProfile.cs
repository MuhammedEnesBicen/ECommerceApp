using AutoMapper;
using ECommerceApp.Application.Features.Products.Commands.Create;
using ECommerceApp.Application.Features.Products.Dtos;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Products.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>().ReverseMap();

    }
}