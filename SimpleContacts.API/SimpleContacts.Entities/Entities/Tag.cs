using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Tag
    {
        Tag()
        {
            CandidatesTags = new HashSet<CandidatesTags>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CandidatesTags> CandidatesTags { get; set; }
    }
}
