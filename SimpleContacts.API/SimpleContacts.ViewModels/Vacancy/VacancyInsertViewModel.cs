using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyInsertViewModel
    {
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
        public string Project { get; set; }
        public VacancyPriority? Priority { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public string Location { get; set; }
        public string Languages { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public DateTime? TargetDate { get; set; }
        public int? NumberOfPositions { get; set; }
        public int? RequiredExperience { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ResponsibleBy { get; set; }
        public string UpdatedBy { get; set; }
        public VacancyStatus? Status { get; set; }
    }
}
