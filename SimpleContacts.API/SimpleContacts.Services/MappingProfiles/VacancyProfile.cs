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
            CreateMap<Vacancy, VacancyViewModel>();
            CreateMap<Vacancy, VacancyGeneralInfoViewModel>().ConvertUsing<VacancyGeneralInfoConverter>();
            CreateMap<VacancyInsertViewModel, Vacancy>().ConvertUsing<VacancyInsertConverter>();
            CreateMap<Vacancy, BasicInfo<Guid>>();

            CreateMap<Department, BasicInfo<Guid>>();
        }
    }
}
