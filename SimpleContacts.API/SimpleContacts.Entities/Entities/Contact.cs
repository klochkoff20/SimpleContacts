using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Contact
    {
        Contact()
        {
            Candidates = new HashSet<Candidate>();
            ContactsDepartments = new HashSet<DepartmentsContacts>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public int? PreferableMethod { get; set; }
        
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<DepartmentsContacts> ContactsDepartments { get; set; }
    }
}
