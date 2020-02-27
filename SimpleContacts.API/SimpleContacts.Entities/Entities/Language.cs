using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Language
    {
        Language()
        {
            CandidatesLanguages = new HashSet<CandidatesLanguages>();
            VacanciesLanguages = new HashSet<VacanciesLanguages>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CandidatesLanguages> CandidatesLanguages { get; set; }
        public virtual ICollection<VacanciesLanguages> VacanciesLanguages { get; set; }
    }
}
