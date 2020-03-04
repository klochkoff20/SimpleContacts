using System;
using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class InsertCandidateConverter : ITypeConverter<CandidateInsertViewModel, Candidate>
    {
        public Candidate Convert(CandidateInsertViewModel source, Candidate destination, ResolutionContext context)
        {
            var candidate = new Candidate
            {
                Id = Guid.NewGuid(),
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Skype = source.Skype,
                LinkedIn = source.LinkedIn,
                Telegram = source.Telegram,
                Facebook = source.Facebook,
                PreferableMethod = source.PreferableMethod,
                BirthDate = source.DateOfBirth,
                Gender = source.Gender,
                Location = source.Location,
                Languages = source.Languages,
                ReadyToRelocate = source.ReadyToRelocate,
                ResponsibleBy = source.ResponsibleBy,
                Industry = source.Industry,
                Expirience = source.Experience,
                CurrentWork = source.CurrentWork,
                CurrentPosition = source.CurrentPosition,
                EmploymentType = source.EmploymentType,
                Education = source.Education,
                DesiredPosition = source.DesiredPosition,
                DesiredSalary = source.DesiredSalary,
                HomePage = source.HomePage,
                AddingDate = DateTime.Now,
                Status = source.Status,
                AddingSource = source.Source,
                Skills = source.Skills,
                Description = source.Description
            };

            return candidate;
        }
    }
}
