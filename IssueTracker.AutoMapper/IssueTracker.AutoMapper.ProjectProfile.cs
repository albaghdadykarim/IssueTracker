using AutoMapper;
using EntityFramework.Data.Models.Domain;
using EntityFramework.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.AutoMapper
{
    public  class ProjectProfile : Profile
    {

        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }

    }
}
