using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Management.Application.Model;
using Management.Core.Entities;
namespace Management.Application.Mapper
{
    public class AppMapperProfile:Profile
    {
        public AppMapperProfile()
        {
            CreateMap<EmployViewModel, EmployModel>().ReverseMap();
        }
    }
}
