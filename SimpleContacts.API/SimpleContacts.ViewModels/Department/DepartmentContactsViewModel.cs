using System;

namespace SimpleContacts.ViewModels
{
    public class DepartmentContactsViewModel : BasicInfo<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
