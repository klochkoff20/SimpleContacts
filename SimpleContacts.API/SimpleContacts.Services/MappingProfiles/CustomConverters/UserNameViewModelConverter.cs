using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class UserNameViewModelConverter : ITypeConverter<User, UserNameViewModel>
    {
        public UserNameViewModel Convert(User source, UserNameViewModel destination, ResolutionContext context)
        {
            var user = new UserNameViewModel
            {
                Id = source.Id,
                FullName = $"{source.FirstName} {source.LastName}"
            };

            return user;
        }
    }
}
