using System;

namespace SimpleContacts.ViewModels
{
    public class UserGeneralInfoViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
