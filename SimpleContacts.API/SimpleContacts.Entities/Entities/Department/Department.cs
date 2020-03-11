using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class Department
    {
        public Department()
        {
            Projects = new HashSet<Project>();
            Vacancies = new HashSet<Vacancy>();
            ContactsDepartments = new HashSet<DepartmentsContacts>();
            DepartmentsAttachments = new HashSet<DepartmentsAttachments>();
        }

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

        public virtual User CreatedUser { get; set; }
        public virtual User ResponsibleUser { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<DepartmentsContacts> ContactsDepartments { get; set; }   
        public virtual ICollection<DepartmentsAttachments> DepartmentsAttachments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
