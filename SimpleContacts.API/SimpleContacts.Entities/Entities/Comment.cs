using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid VacancyId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public CommentType Type { get; set; }
        
        public virtual Department Department { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public virtual User User { get; set; }
    }
}
