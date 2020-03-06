using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyGeneralInfoViewModel : BasicInfo<Guid>
    {
        public BasicInfo<Guid> Department { get; set; }
        public string Project { get; set; }
        public string Priority { get; set; }
        public DateTime? TargetDate { get; set; }
        public BasicInfo<string> ResponsibleUser { get; set; }
        public VacancyStatus Status { get; set; }
    }
}
