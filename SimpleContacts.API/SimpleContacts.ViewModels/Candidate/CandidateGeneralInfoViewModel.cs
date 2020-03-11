using System;
using System.Collections.Generic;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class CandidateGeneralInfoViewModel : BasicInfo<Guid>
    {
        public string DesiredPosition { get; set; }
        public BasicInfo<string> ResponsibleUser { get; set; }
        public DateTime? AddingDate { get; set; }
        public string AddingSource { get; set; }
        public CandidateStatus? Status { get; set; }
        public List<string> Skills { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
