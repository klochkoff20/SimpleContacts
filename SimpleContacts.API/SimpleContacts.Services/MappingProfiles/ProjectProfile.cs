using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.Services.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>().ReverseMap();

        }
    }
}
