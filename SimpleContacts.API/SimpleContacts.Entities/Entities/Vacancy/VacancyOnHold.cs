using System;

namespace SimpleContacts.Entities.Entities
{
    public class VacancyOnHold
    {
        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
