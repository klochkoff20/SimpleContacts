using SimpleContacts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.ViewModels
{
    public class DepartmentGeneralInfoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DepartmentStatus Status { get; set; }
        public IList<ProjectViewModel> Projects { get; set; }
        public IList<DepartmentVacancyViewModel> Vacancies { get; set; }
        public UserGeneralInfoViewModel ResponsibleUser { get; set; }
        public IList<DepartmentContactsViewModel> DepartmentContacts { get; set; }
    }
}
