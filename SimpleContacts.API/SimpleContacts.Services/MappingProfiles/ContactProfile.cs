using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.MappingProfiles.CustomConverters;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>()
                .ForMember(
                            viewModel => viewModel.FullName,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );

            CreateMap<InsertContactViewModel, Contact>().ConvertUsing<InsertContactConverter>();



            //CreateMap<ContactViewModel, Contact>()
            //    .ForMember(
            //                candidate => candidate.FirstName,
            //                opt => opt.MapFrom(src => src.FullName.Split(null).GetValue(0))
            //    )
            //    .ForMember(
            //                candidate => candidate.LastName,
            //                opt => opt.MapFrom(src => src.FullName.Split(null).GetValue(1))
            //    );

        }
    }
}
