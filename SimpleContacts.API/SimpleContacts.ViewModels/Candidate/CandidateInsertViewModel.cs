using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class CandidateInsertViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public bool ReadyToRelocate { get; set; }
        public string DesiredPosition { get; set; }
        public string Industry { get; set; }
        public CandidateExperience Experience { get; set; }
        public string CurrentWork { get; set; }
        public string CurrentPosition { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string Education { get; set; }
        public string Languages { get; set; }
        public int DesiredSalary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public int PreferableMethod { get; set; }
        public string HomePage { get; set; }
        public CandidateStatus Status { get; set; }
        public CandidateSource Source { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }
        public string ResponsibleBy { get; set; }
    }
}
