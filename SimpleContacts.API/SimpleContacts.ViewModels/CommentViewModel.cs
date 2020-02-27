using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public CandidateViewModel CandidateId { get; set; }
        public VacancyGeneralInfoViewModel VacancyId { get; set; }
        public UserViewModel UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public CommentType Type { get; set; }
    }
}
