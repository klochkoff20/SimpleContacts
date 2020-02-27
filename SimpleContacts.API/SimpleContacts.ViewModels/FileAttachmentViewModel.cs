using System;
using System.Collections.Generic;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class FileAttachmentViewModel : BasicInfo<Guid>
    {
        public DateTime AddedAt { get; set; }
        public UserViewModel AddedBy { get; set; }

        //public IList<DepartmentsAttachments> DepartmentsAttachments { get; set; }
        //public IList<VacanciesAttachments> VacanciesAttachments { get; set; }
        //public IList<CandidatesAttachments> CandidatesAttachments { get; set; }
    }
}
