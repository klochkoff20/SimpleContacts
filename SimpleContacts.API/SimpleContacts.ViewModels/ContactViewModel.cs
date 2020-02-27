using System;
using System.Collections.Generic;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public string GooglePlus { get; set; }
        public int? PreferableMethod { get; set; }

        //public IList<CandidateViewModel> Candidates { get; set; }
        //public IList<DepartmentsContacts> ContactsDepartments { get; set; }
    }
}
