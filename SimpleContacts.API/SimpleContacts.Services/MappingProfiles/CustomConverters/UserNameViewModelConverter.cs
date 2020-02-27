using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class UserNameViewModelConverter : ITypeConverter<User, BasicInfo<string>>
    {
        public BasicInfo<string> Convert(User source, BasicInfo<string> destination, ResolutionContext context)
        {
            var user = new BasicInfo<string>
            {
                Id = source.Id,
                Name = $"{source.FirstName} {source.LastName}"
            };

            return user;
        }
    }
}
