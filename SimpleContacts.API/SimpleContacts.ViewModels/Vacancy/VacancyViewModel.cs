using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BasicInfo<Guid> Department { get; set; }
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
        public BasicInfo<string> CreatedUser { get; set; }
        public DateTime? CreatedAt { get; set; }
        public BasicInfo<string> ResponsibleUser { get; set; }
        public BasicInfo<string> UpdatedUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public VacancyStatus? Status { get; set; }

        // public IList<CommentViewModel> Comments { get; set; }
        // public IList<VacanciesAttachments> VacanciesAttachments { get; set; }
        // public IList<CandidatesVacancies> CandidatesVacancies { get; set; }
    }
}
