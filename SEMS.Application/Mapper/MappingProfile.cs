using AutoMapper;
using SEMS.Application.Handlers.Post.Command;
using SEMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post , SEMS.Application.Handlers.Post.Command.Create.CreateRequest>().ReverseMap();
            CreateMap<Post, SEMS.Application.Handlers.Post.Command.Create.CreateResponse>().ReverseMap();
        }


    }
}
