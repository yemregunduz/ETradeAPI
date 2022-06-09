using AutoMapper;
using Common.Application.Wrappers.Paging;
using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Domain.Entities;

namespace ETradeAPI.Application.Features.Products.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product,UpdateProductCommand>().ReverseMap();
        }
    }
}
