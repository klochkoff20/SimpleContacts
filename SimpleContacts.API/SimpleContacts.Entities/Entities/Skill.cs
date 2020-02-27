using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class Skill
    {
        Skill()
        {
            CandidatesSkills = new HashSet<CandidatesSkills>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CandidatesSkills> CandidatesSkills { get; set; }
    }
}
