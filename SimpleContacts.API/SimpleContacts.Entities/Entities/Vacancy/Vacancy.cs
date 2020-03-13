using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class Vacancy
    {
        public Vacancy()
        {
            Comments = new HashSet<Comment>();
            VacanciesAttachments = new HashSet<VacanciesAttachments>();
            CandidatesVacancies = new HashSet<CandidatesVacancies>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
        public string Project { get; set; }
        public VacancyPriority? Priority { get; set; }
        public DateTime? TargetDate { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public string Location { get; set; }
        public string Languages { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public int? RequiredExperience { get; set; }
        public int? NumberOfPositions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ResponsibleBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public VacancyStatus? Status { get; set; }

        public virtual Department Department { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User ResponsibleUser { get; set; }
        public virtual User UpdatedUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<VacanciesAttachments> VacanciesAttachments { get; set; }
        public virtual ICollection<CandidatesVacancies> CandidatesVacancies { get; set; }
    }
}
