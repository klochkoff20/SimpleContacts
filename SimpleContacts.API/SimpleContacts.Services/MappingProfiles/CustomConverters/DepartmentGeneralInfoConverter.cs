using System;
using System.Collections.Generic;
using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class DepartmentGeneralInfoConverter : ITypeConverter<Department, DepartmentGeneralInfoViewModel>
    {
        public DepartmentGeneralInfoViewModel Convert(Department source, DepartmentGeneralInfoViewModel destination, ResolutionContext context)
        {
            var department = new DepartmentGeneralInfoViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Status = source.Status,
                Vacancies = context.Mapper.Map<List<BasicInfo<Guid>>>(source.Vacancies),
                Projects = context.Mapper.Map<List<BasicInfo<Guid>>>(source.Projects),
                ResponsibleUser = context.Mapper.Map<UserGeneralInfoViewModel>(source.ResponsibleUser),
                Phone = source.Phone,
                Email = source.Email
                //DepartmentContacts = context.Mapper.Map<List<DepartmentContactsViewModel>>(source.ContactsDepartments)
            };

            return department;
        }
    }
}
