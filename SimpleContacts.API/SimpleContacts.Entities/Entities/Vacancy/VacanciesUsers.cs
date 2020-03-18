using System;

namespace SimpleContacts.Entities.Entities
{
    public class VacanciesUsers
    {
        public Guid VacancyId { get; set; }
        public string UserId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
        public virtual User User { get; set; }
    }
}
