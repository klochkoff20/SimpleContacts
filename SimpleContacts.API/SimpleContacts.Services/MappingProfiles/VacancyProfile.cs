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
            CreateMap<VacancyInsertViewModel, Vacancy>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.Now;
                    dest.UpdatedAt = DateTime.Now;
                });

            CreateMap<VacancyUpdateViewModel, Vacancy>()
                .AfterMap((src, dest) =>
                {
                    dest.UpdatedAt = DateTime.Now;
                });

            CreateMap<Vacancy, BasicInfo<Guid>>();

            CreateMap<VacanciesUsers, VacanciesUsersViewModel>().ReverseMap();

            CreateMap<VacancyOnHold, VacancyOnHoldViewModel>().ReverseMap();
        }
    }
}
