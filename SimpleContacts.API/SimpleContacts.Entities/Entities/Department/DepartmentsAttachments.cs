using System;

namespace SimpleContacts.Entities.Entities
{
    public class DepartmentsAttachments
    {
        public Guid FileId { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual FileAttachment FileAttachment { get; set; }
        public virtual Department Department { get; set; }
    }
}
