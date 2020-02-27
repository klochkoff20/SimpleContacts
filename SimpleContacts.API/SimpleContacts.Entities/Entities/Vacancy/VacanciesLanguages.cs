using System;

namespace SimpleContacts.Entities.Entities
{
    public class VacanciesLanguages
    {
        public Guid VacancyId { get; set; }
        public Guid LanguageId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
        public virtual Language Language { get; set; }
    }
}
