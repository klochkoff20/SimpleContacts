using System;

namespace SimpleContacts.Entities.Entities
{
    public class VacanciesAttachments
    {
        public Guid FileId { get; set; }
        public Guid VacancyId { get; set; }

        public virtual FileAttachment FileAttachment { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
