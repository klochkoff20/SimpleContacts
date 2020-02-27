using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Common.Enums;
using System;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class VacancyGeneralInfoViewModelConverter : ITypeConverter<Vacancy, VacancyGeneralInfoViewModel>
    {
        public VacancyGeneralInfoViewModel Convert(Vacancy source, VacancyGeneralInfoViewModel destination, ResolutionContext context)
        {
            var vacancy = new VacancyGeneralInfoViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Department = context.Mapper.Map<BasicInfo<Guid>>(source.Department),
                Project = context.Mapper.Map<BasicInfo<Guid>>(source.Project),
                Priority = Enum.GetName(typeof(VacancyPriority), source.Priority),
                TargetDate = source.TargetDate,
                ResponsibleUser = context.Mapper.Map<BasicInfo<string>>(source.ResponsibleUser),
                Salary = $"{source.SalaryMin}-{source.SalaryMax}$",
                Status = source.Status
            };

            return vacancy;
        }
    }
}
