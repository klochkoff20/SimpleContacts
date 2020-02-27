using System;

namespace SimpleContacts.Entities.Entities
{
    public class CandidatesSkills
    {
        public Guid CandidateId { get; set; }
        public Guid SkillId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
