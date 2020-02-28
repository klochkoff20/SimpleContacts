using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class DepartmentContactsConverter : ITypeConverter<DepartmentsContacts, DepartmentContactsViewModel>
    {
        public DepartmentContactsViewModel Convert(DepartmentsContacts source, DepartmentContactsViewModel destination, ResolutionContext context)
        {
            var contact = new DepartmentContactsViewModel
            {
                Id = source.DepartmentId,
                Name = $"{source.Contact.FirstName} {source.Contact.LastName}",
                PhoneNumber = source.Contact.PhoneNumber,
                Email = source.Contact.Email
            };

            return contact;
        }
    }
}
