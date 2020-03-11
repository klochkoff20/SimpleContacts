using System;
using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class CandidateUpdateConverter : ITypeConverter<CandidateUpdateViewModel, Candidate>
    {
        public Candidate Convert(CandidateUpdateViewModel source, Candidate destination, ResolutionContext context)
        {
            var candidate = new Candidate
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Skype = source.Skype,
                LinkedIn = source.LinkedIn,
                Telegram = source.Telegram,
                Facebook = source.Facebook,
                PreferableMethod = source.PreferableMethod,
                DateOfBirth = source.DateOfBirth,
                Gender = source.Gender,
                Location = source.Location,
                Languages = source.Languages,
                ReadyToRelocate = source.ReadyToRelocate,
                ResponsibleBy = source.ResponsibleBy,
                Industry = source.Industry,
                Experience = source.Experience,
                CurrentWork = source.CurrentWork,
                CurrentPosition = source.CurrentPosition,
                EmploymentType = source.EmploymentType,
                Education = source.Education,
                DesiredPosition = source.DesiredPosition,
                DesiredSalary = source.DesiredSalary,
                HomePage = source.HomePage,
                UpdateDate = DateTime.Now,
                Status = source.Status,
                Source = source.Source,
                Skills = source.Skills,
                Description = source.Description
            };

            return candidate;
        }
    }
}
