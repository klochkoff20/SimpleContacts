using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.MappingProfiles.CustomConverters;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateViewModel>().ReverseMap();

            CreateMap<Candidate, CandidateGeneralInfoViewModel>().ConvertUsing<CandidateGeneralInfoConverter>();

            CreateMap<CandidateInsertViewModel, Candidate>().ConvertUsing<CandidateInsertConverter>();
            
        }
    }
}
