using System;

namespace SimpleContacts.ViewModels
{
    public class VacanciesUsersViewModel
    {
        public Guid VacancyId { get; set; }
        public BasicInfo<string> User { get; set; }
    }
}
