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
            CandidatesLanguages = new HashSet<CandidatesLanguages>();
            CandidatesAttachments = new HashSet<CandidatesAttachments>();
            CandidatesSkills = new HashSet<CandidatesSkills>();
            CandidatesTags = new HashSet<CandidatesTags>();
        }

        public Guid Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public Guid ContactId { get; set; }
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
        public Currency Currency { get; set; }
        public string HomePage { get; set; }
        public DateTime? AddingDate { get; set; } 
        public CandidateStatus Status { get; set; }
        public CandidateSource AddingSource { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }

        public virtual User ResponsibleUser { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CandidatesVacancies> CandidatesVacancies { get; set; }
        public virtual ICollection<CandidatesLanguages> CandidatesLanguages { get; set; }
        public virtual ICollection<CandidatesAttachments> CandidatesAttachments { get; set; }
        public virtual ICollection<CandidatesSkills> CandidatesSkills { get; set; }
        public virtual ICollection<CandidatesTags> CandidatesTags { get; set; }
    }
}
