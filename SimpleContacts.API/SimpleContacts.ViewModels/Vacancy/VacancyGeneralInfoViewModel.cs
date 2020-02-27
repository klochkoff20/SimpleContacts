using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyGeneralInfoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public VacancyDepartmentViewModel Department { get; set; }
        public ProjectViewModel Project { get; set; }
        public string Priority { get; set; }
        public DateTime TargetDate { get; set; }
        public string Salary { get; set; }
        public UserNameViewModel ResponsibleUser { get; set; }
        public VacancyStatus Status { get; set; }
    }
}
