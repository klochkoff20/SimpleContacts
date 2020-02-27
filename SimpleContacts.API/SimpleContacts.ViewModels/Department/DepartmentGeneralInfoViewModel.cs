using SimpleContacts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.ViewModels
{
    public class DepartmentGeneralInfoViewModel : BasicInfo<Guid>
    {
        public DepartmentStatus Status { get; set; }
        public IList<BasicInfo<Guid>> Projects { get; set; }
        public IList<DepartmentVacancyViewModel> Vacancies { get; set; }
        public UserGeneralInfoViewModel ResponsibleUser { get; set; }
        public IList<DepartmentContactsViewModel> DepartmentContacts { get; set; }
    }
}
