using AutoMapper;
using Server.Application.Features.AuthFeatures.SignIn;
using Server.Application.Features.AuthFeatures.SignUp;
using Server.Application.Features.ProductFeatures.Create;
using Server.Application.Features.ProductFeatures.GetAll;
using Server.Application.Features.ProductFeatures.GetById;
using Server.Application.Features.ProductFeatures.Update;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        // AppUser mappings
        CreateMap<AppUser, AppUserDto>().ReverseMap();
        CreateMap<AppUser, SignInCommand>().ReverseMap();
        CreateMap<AppUser, SignUpCommand>().ReverseMap();

        //Product mappings
        CreateMap<Product, GetAllProductsQueryResult>().ReverseMap();
        CreateMap<Product, GetProductByIdQueryResult>().ReverseMap();
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
    }
}
