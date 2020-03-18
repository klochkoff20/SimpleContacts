using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class VacancyGeneralInfoViewModel : BasicInfo<Guid>
    {
        public BasicInfo<Guid> Department { get; set; }
        public string Project { get; set; }
        public string Priority { get; set; }
        public DateTime? TargetDate { get; set; }
        public VacancyStatus? Status { get; set; }

        public IList<VacanciesUsersViewModel> ResponsibleUsers { get; set; }
    }
}
