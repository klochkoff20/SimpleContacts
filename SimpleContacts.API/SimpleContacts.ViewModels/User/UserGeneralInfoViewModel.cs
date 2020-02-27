using System;

namespace SimpleContacts.ViewModels
{
    public class UserGeneralInfoViewModel : BasicInfo<string>
    {
        public string Email { get; set; }
        public string[] Roles { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
