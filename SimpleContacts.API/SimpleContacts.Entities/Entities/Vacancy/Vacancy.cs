﻿using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class Vacancy
    {
        Vacancy()
        {
            Comments = new HashSet<Comment>();
            VacanciesLanguages = new HashSet<VacanciesLanguages>();
            VacanciesAttachments = new HashSet<VacanciesAttachments>();
            CandidatesVacancies = new HashSet<CandidatesVacancies>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ProjectId { get; set; }
        public VacancyPriority Priority { get; set; }
        public DateTime TargetDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Location { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public int? RequiredExperience { get; set; }
        public int? NumberOfPositions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ResponsibleBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
        public string HardSkills { get; set; }
        public string OptionalHardSkills { get; set; }
        public string SoftSkills { get; set; }
        public VacancyStatus Status { get; set; }

        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User ResponsibleUser { get; set; }
        public virtual User UpdatedUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<VacanciesLanguages> VacanciesLanguages { get; set; }
        public virtual ICollection<VacanciesAttachments> VacanciesAttachments { get; set; }
        public virtual ICollection<CandidatesVacancies> CandidatesVacancies { get; set; }
    }
}
