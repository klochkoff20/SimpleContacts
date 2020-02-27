using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum DepartmentStatus : byte
    {
        [Description("In Progress")]
        InProgress = 0,

        [Description("Future")]
        Future,

        [Description("On Hold")]
        OnHold,

        [Description("AllDone")]
        AllDone,

        [Description("Canceled")]
        Canceled,

        [Description("Deleted")]
        Deleted
    }
}
