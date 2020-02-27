using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class DepartmentGeneralInfoViewModelConverter : ITypeConverter<Department, DepartmentGeneralInfoViewModel>
    {
        public DepartmentGeneralInfoViewModel Convert(Department source, DepartmentGeneralInfoViewModel destination, ResolutionContext context)
        {
            var department = new DepartmentGeneralInfoViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Status = source.Status,
                Vacancies = context.Mapper.Map<List<DepartmentVacancyViewModel>>(source.Vacancies),
                Projects = context.Mapper.Map<List<ProjectViewModel>>(source.Projects),
                ResponsibleUser = context.Mapper.Map<UserGeneralInfoViewModel>(source.ResponsibleUser),
                DepartmentContacts = context.Mapper.Map<List<DepartmentContactsViewModel>>(source.ContactsDepartments)
            };

            return department;
        }
    }
}
