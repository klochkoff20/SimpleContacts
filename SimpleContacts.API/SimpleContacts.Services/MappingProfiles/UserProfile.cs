using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.MappingProfiles.CustomConverters;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<User, UserGeneralInfoViewModel>()
                .ForMember(
                            viewModel => viewModel.FullName,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );

            CreateMap<User, UserNameViewModel>().ConvertUsing<UserNameViewModelConverter>();
        }
    }
}
