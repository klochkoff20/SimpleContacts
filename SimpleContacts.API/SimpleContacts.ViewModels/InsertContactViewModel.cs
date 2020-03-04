using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.ViewModels
{
    public class InsertContactViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public int? PreferableMethod { get; set; }
    }
}
