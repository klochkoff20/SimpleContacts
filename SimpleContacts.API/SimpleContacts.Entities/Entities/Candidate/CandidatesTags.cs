using System;

namespace SimpleContacts.Entities.Entities
{
    public class CandidatesTags
    {
        public Guid CandidateId { get; set; }
        public Guid TagId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
