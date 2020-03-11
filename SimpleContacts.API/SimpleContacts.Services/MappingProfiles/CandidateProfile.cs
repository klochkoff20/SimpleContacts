using System;
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

            CreateMap<CandidateInsertViewModel, Candidate>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.AddingDate = DateTime.Now;
                    dest.UpdateDate = DateTime.Now;
                });

            CreateMap<CandidateUpdateViewModel, Candidate>()
                .AfterMap((src, dest) =>
                {
                    dest.UpdateDate = DateTime.Now;
                });
        }
    }
}
