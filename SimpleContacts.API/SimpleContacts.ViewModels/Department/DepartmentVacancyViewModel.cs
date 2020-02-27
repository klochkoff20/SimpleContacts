using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class DepartmentVacancyViewModel : BasicInfo<Guid>
    {
        public BasicInfo<Guid> Project { get; set; }
        public VacancyPriority Priority { get; set; }
        public DateTime TargetDate { get; set; }
        public string Salary { get; set; }
        public UserGeneralInfoViewModel ResponsibleUser { get; set; }
        public VacancyStatus Status { get; set; }
    }
}
