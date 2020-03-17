using System;
using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class VacancyInsertConverter : ITypeConverter<VacancyInsertViewModel, Vacancy>
    {
        public Vacancy Convert(VacancyInsertViewModel source, Vacancy destination, ResolutionContext context)
        {
            var vacancy = new Vacancy
            {
                Id = Guid.NewGuid(),
                Name = source.Name,
                DepartmentId = source.DepartmentId,
                Project = source.Project,
                Priority = source.Priority,
                TargetDate = source.TargetDate,
                EmploymentType = source.EmploymentType,
                Location = source.Location,
                SalaryMin = source.SalaryMin,
                SalaryMax = source.SalaryMax,
                RequiredExperience = source.RequiredExperience,
                NumberOfPositions = source.NumberOfPositions,
                CreatedBy = source.CreatedBy,
                CreatedAt = DateTime.Now,
                ResponsibleBy = source.ResponsibleBy,
                UpdatedBy = source.UpdatedBy,
                UpdatedAt = DateTime.Now,
                Requirements = source.Requirements,
                Description = source.Description,
                Status = source.Status
            };

            return vacancy;
        }
    }
}
