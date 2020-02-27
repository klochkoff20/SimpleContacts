using System;

namespace SimpleContacts.Entities.Entities
{
    public class CandidatesLanguages
    {
        public Guid CandidateId { get; set; }
        public Guid LanguageId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Language Language { get; set; }
    }
}
