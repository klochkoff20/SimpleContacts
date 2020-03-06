using System;
using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class VacancyGeneralInfoConverter : ITypeConverter<Vacancy, VacancyGeneralInfoViewModel>
    {
        public VacancyGeneralInfoViewModel Convert(Vacancy source, VacancyGeneralInfoViewModel destination, ResolutionContext context)
        {
            var vacancy = new VacancyGeneralInfoViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Department = context.Mapper.Map<BasicInfo<Guid>>(source.Department),
                Project = source.Project,
                Priority = Enum.GetName(typeof(VacancyPriority), source.Priority),
                TargetDate = source.TargetDate,
                ResponsibleUser = context.Mapper.Map<BasicInfo<string>>(source.ResponsibleUser),
                Status = source.Status
            };

            return vacancy;
        }
    }
}
