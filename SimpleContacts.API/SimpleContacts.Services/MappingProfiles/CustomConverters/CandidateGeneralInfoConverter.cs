using System;
using System.Linq;
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
                Name = $"{source.FirstName} {source.LastName}",
                DesiredPosition = source.DesiredPosition,
                Level = Enum.GetName(typeof(CandidateLevel), source.Level),
                AddingDate = source.AddingDate,
                AddingSource = Enum.GetName(typeof(CandidateSource), source.Source),
                Skills = source.Skills.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                Status = source.Status
            };

            return candidate;
        }
    }
}
