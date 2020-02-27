using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Project
    {
        Project()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
