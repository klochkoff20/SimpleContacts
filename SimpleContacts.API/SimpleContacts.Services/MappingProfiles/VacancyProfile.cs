using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.MappingProfiles.CustomConverters;
using System;

namespace SimpleContacts.Services.MappingProfiles
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<Vacancy, VacancyViewModel>().ReverseMap();
            CreateMap<Vacancy, BasicInfo<Guid>>().ReverseMap();


            CreateMap<Vacancy, VacancyGeneralInfoViewModel>().ConvertUsing<VacancyGeneralInfoViewModelConverter>();

            CreateMap<Department, BasicInfo<Guid>>();
        }
    }
}
