using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public DepartmentStatus Status { get; set; }
        public string Description { get; set; }
        public UserViewModel CreatedUser { get; set; }
        public UserViewModel ResponsibleUser { get; set; }

        //public IList<ProjectViewModel> Projects { get; set; }
        //public IList<VacancyViewModel> Vacancies { get; set; }
        //public IList<DepartmentsContacts> ContactsDepartments { get; set; }
        //public IList<DepartmentsAttachments> DepartmentsAttachments { get; set; }
    }
}
