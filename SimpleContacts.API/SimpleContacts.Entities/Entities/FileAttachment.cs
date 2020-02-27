using System;
using System.Collections.Generic;

namespace SimpleContacts.Entities.Entities
{
    public class FileAttachment
    {
        FileAttachment()
        {
            DepartmentsAttachments = new HashSet<DepartmentsAttachments>();
            VacanciesAttachments = new HashSet<VacanciesAttachments>();
            CandidatesAttachments = new HashSet<CandidatesAttachments>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedAt { get; set; }
        public string AddedBy { get; set; }

        public virtual User AddedUser { get; set; }
        public virtual ICollection<DepartmentsAttachments> DepartmentsAttachments { get; set; }
        public virtual ICollection<VacanciesAttachments> VacanciesAttachments { get; set; }
        public virtual ICollection<CandidatesAttachments> CandidatesAttachments { get; set; }
    }
}
