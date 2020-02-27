using System;

namespace SimpleContacts.Entities.Entities
{
    public class CandidatesAttachments
    {
        public Guid FileId { get; set; }
        public Guid CandidateId { get; set; }

        public virtual FileAttachment FileAttachment { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
