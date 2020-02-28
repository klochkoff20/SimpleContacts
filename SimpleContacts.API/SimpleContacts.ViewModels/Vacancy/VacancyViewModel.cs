using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyViewModel : BasicInfo<Guid>
    {
        public DepartmentViewModel Department { get; set; }
        public BasicInfo<Guid> Project { get; set; }
        public VacancyPriority Priority { get; set; }
        public DateTime TargetDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Location { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public int? RequiredExperience { get; set; }
        public int? NumberOfPositions { get; set; }
        public UserViewModel CreatedUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserViewModel ResponsibleUser { get; set; }
        public UserViewModel UpdatedUser { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
        public string HardSkills { get; set; }
        public string OptionalHardSkills { get; set; }
        public string SoftSkills { get; set; }
        public VacancyStatus Status { get; set; }

        //public IList<Comment> Comments { get; set; }
        //public IList<VacanciesLanguages> VacanciesLanguages { get; set; }
        //public IList<VacanciesAttachments> VacanciesAttachments { get; set; }
        //public IList<CandidatesVacancies> CandidatesVacancies { get; set; }
    }
}
