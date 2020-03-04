using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Entities.Entities
{
    public class Candidate
    {
        public Candidate()
        {
            Comments = new HashSet<Comment>();
            CandidatesVacancies = new HashSet<CandidatesVacancies>();
            CandidatesAttachments = new HashSet<CandidatesAttachments>();
            CandidatesTags = new HashSet<CandidatesTags>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public string Languages { get; set; }
        public bool ReadyToRelocate { get; set; }
        public string ResponsibleBy { get; set; }
        public string Industry { get; set; }
        public CandidateExperience Expirience { get; set; }
        public string CurrentWork { get; set; }
        public string CurrentPosition { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Education { get; set; }
        public string DesiredPosition { get; set; }
        public int DesiredSalary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public int? PreferableMethod { get; set; }
        public string HomePage { get; set; }
        public DateTime? AddingDate { get; set; } 
        public CandidateStatus Status { get; set; }
        public CandidateSource AddingSource { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }

        public virtual User ResponsibleUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CandidatesVacancies> CandidatesVacancies { get; set; }
        public virtual ICollection<CandidatesAttachments> CandidatesAttachments { get; set; }
        public virtual ICollection<CandidatesTags> CandidatesTags { get; set; }
    }
}
