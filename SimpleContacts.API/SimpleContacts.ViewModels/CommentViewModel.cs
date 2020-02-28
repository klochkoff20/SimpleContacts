using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public BasicInfo<Guid> Candidate { get; set; }
        public BasicInfo<Guid> Vacancy { get; set; }
        public BasicInfo<string> User { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public CommentType Type { get; set; }
    }
}
