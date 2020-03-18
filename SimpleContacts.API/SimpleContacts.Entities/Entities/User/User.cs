using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            AddedFiles = new HashSet<FileAttachment>();
            ResponsibleCandidates = new HashSet<Candidate>();
            CreatedVacancies = new HashSet<Vacancy>();
            ResponsibleVacancies = new HashSet<VacanciesUsers>();
            UpdatedVacancies = new HashSet<Vacancy>();
            CreatedDepartments = new HashSet<Department>();
            ResponsibleDepartments = new HashSet<Department>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        //public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FileAttachment> AddedFiles { get; set; }
        public virtual ICollection<Candidate> ResponsibleCandidates { get; set; }
        public virtual ICollection<Vacancy> CreatedVacancies { get; set; }
        public virtual ICollection<VacanciesUsers> ResponsibleVacancies { get; set; }
        public virtual ICollection<Vacancy> UpdatedVacancies { get; set; }
        public virtual ICollection<Department> CreatedDepartments { get; set; }
        public virtual ICollection<Department> ResponsibleDepartments { get; set; }
    }
}
