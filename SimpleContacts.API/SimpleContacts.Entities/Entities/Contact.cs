using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Contact
    {
        public Contact()
        {
            Candidates = new HashSet<Candidate>();
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
    }
}
