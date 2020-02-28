using SimpleContacts.Common.Enums;
using System;
using System.Collections.Generic;

namespace SimpleContacts.ViewModels
{
    public class DepartmentGeneralInfoViewModel : BasicInfo<Guid>
    {
        public DepartmentStatus Status { get; set; }
        public IList<BasicInfo<Guid>> Projects { get; set; }
        public IList<BasicInfo<Guid>> Vacancies { get; set; }
        public BasicInfo<string> ResponsibleUser { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public IList<DepartmentContactsViewModel> DepartmentContacts { get; set; }
    }
}
