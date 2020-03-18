using System;
using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class DepartmentInsertConverter : ITypeConverter<DepartmentInsertViewModel, Department>
    {
        public Department Convert(DepartmentInsertViewModel source, Department destination, ResolutionContext context)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = source.Name,
                Location = source.Location,
                Phone = source.Phone,
                Email = source.Email,
                Skype = source.Skype,
                Description = source.Description,
                CreatedBy = source.CreatedBy,
                CreatedAt = DateTime.Now
            };

            return department;
        }
    }
}
