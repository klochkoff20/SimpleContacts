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
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public DepartmentStatus? Status { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ResponsibleBy { get; set; }

        public BasicInfo<string> CreatedUser { get; set; }
        public BasicInfo<string> ResponsibleUser { get; set; }
        public IList<Project> Projects { get; set; }
        public IList<Vacancy> Vacancies { get; set; }
        public IList<DepartmentsContacts> ContactsDepartments { get; set; }
        public IList<DepartmentsAttachments> DepartmentsAttachments { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
