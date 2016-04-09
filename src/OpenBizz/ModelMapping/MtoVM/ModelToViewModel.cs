using AutoMapper;
using OpenBiz.Models;
using OpenBiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.ModelMapping.MtoVM
{
    public class ModelToViewModel:Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductViewModel>().
                ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.Category.CategoryID));
        }
    }
}
