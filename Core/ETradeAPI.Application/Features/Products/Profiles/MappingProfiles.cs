using AutoMapper;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Wrappers.Paging;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
        }
    }
}
