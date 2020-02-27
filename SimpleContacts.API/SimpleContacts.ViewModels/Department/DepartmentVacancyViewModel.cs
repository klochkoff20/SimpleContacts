using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class DepartmentVacancyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProjectViewModel Project { get; set; }
        public VacancyPriority Priority { get; set; }
        public DateTime TargetDate { get; set; }
        public string Salary { get; set; }
        public UserGeneralInfoViewModel ResponsibleUser { get; set; }
        public VacancyStatus Status { get; set; }
    }
}
