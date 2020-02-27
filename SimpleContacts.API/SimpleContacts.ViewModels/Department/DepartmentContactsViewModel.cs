using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.ViewModels
{
    public class DepartmentContactsViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
    }
}
