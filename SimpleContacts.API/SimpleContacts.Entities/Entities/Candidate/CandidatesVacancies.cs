using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class CandidatesVacancies
    {
        public Guid CandidateId { get; set; }
        public Guid VacancyId { get; set; }
        public CandidateStage Stage { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
