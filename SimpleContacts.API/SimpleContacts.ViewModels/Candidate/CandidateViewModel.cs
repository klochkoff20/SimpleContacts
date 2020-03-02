﻿using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public ContactViewModel Contact { get; set; }
        public bool ReadyToRelocate { get; set; }
        public UserViewModel ResponsibleUser { get; set; }
        public string Industry { get; set; }
        public CandidateExperience Expirience { get; set; }
        public string CurrentWork { get; set; }
        public string CurrentPosition { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Education { get; set; }
        public string DesiredPosition { get; set; }
        public int DesiredSalary { get; set; }
        public string HomePage { get; set; }
        public DateTime? AddingDate { get; set; }
        public CandidateStatus Status { get; set; }
        public CandidateSource AddingSource { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }

        public IList<Comment> Comments { get; set; }
        //public IList<CandidatesVacancies> CandidatesVacancies { get; set; }
        //public IList<CandidatesLanguages> CandidatesLanguages { get; set; }
        //public IList<CandidatesAttachments> CandidatesAttachments { get; set; }
        //public IList<CandidatesSkills> CandidatesSkills { get; set; }
        //public IList<CandidatesTags> CandidatesTags { get; set; }
    }
}
