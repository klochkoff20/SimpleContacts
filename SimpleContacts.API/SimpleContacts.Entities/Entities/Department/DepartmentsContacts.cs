using System;

namespace SimpleContacts.Entities.Entities
{
    public class DepartmentsContacts
    {
        public Guid ContactId { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Department Department { get; set; }
    }
}
