using System;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.ViewModels
{
    public class DepartmentInsertViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public DepartmentStatus Status { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ResponsibleBy { get; set; }
    }
}
