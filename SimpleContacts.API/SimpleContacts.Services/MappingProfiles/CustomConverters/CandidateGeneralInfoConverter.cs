using System;
using AutoMapper;
using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class CandidateGeneralInfoConverter : ITypeConverter<Candidate, CandidateGeneralInfoViewModel>
    {
        public CandidateGeneralInfoViewModel Convert(Candidate source, CandidateGeneralInfoViewModel destination, ResolutionContext context)
        {
            var candidate = new CandidateGeneralInfoViewModel
            {
                Id = source.Id,
                Name = $"{source.Contact.FirstName} {source.Contact.LastName}",
                DesiredPosition = source.DesiredPosition,
                ResponsibleUser = context.Mapper.Map<BasicInfo<string>>(source.ResponsibleUser),
                AddingDate = source.AddingDate,
                AddingSource = Enum.GetName(typeof(CandidateSource), source.AddingSource),
                Status = source.Status
            };

            return candidate;
        }
    }
}
