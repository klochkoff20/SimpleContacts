using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateViewModel>().ReverseMap();

            
        }
    }
}
