using AutoMapper;
using OpenBiz.Models;
using OpenBiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.ModelMapping.VMtoM
{
    public class ViewModelToModel : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProductViewModel, Product>().
                ForMember(dest => dest.ProductID, opt => opt.Ignore());
        }
    }
}
