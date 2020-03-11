using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.MappingProfiles.CustomConverters;
using SimpleContacts.ViewModels;
using System;

namespace SimpleContacts.Services.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Department, DepartmentGeneralInfoViewModel>().ConvertUsing<DepartmentGeneralInfoConverter>();
            CreateMap<DepartmentInsertViewModel, Department>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.Now;
                    dest.UpdatedAt = DateTime.Now;
                });

            CreateMap<DepartmentUpdateViewModel, Department>()
                .AfterMap((src, dest) =>
                {
                    dest.UpdatedAt = DateTime.Now;
                });

            CreateMap<DepartmentsContacts, DepartmentContactsViewModel>().ReverseMap();

            CreateMap<Vacancy, DepartmentVacancyViewModel>()
                .ForMember(
                    viewModel => viewModel.Salary,
                    opt => opt.MapFrom(src => $"{src.SalaryMin}-{src.SalaryMax}$")
                );

            CreateMap<DepartmentsContacts, DepartmentContactsViewModel>().ConvertUsing<DepartmentContactsConverter>();
        }
    }
}
