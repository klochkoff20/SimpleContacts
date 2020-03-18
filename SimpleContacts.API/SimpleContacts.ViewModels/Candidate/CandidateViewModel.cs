﻿using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Location { get; set; }
        public bool? ReadyToRelocate { get; set; }
        public string Languages { get; set; }
        public string Industry { get; set; }
        public DateTime? StartedPractice { get; set; }
        public string CurrentWork { get; set; }
        public string CurrentPosition { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public string Education { get; set; }
        public string DesiredPosition { get; set; }
        public CandidateLevel Level { get; set; }
        public int? DesiredSalary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public int? PreferableMethod { get; set; }
        public string HomePage { get; set; }
        public DateTime? AddingDate { get; set; }
        public CandidateStatus? Status { get; set; }
        public CandidateSource? Source { get; set; }
        public string Skills { get; set; }
        public string SkillsAsText { get; set; }
        public string Description { get; set; }

        public BasicInfo<string> ResponsibleUser { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<CandidatesVacancies> CandidatesVacancies { get; set; }
        public IList<CandidatesAttachments> CandidatesAttachments { get; set; }
    }
}
