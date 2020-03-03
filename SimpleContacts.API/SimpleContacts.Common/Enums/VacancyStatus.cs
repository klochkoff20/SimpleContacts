using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancyStatus : byte
    {
        [Description("New")]
        New = 0,

        [Description("In Progress")]
        InProgress,

        [Description("On Hold")]
        OnHold,

        [Description("Complete")]
        Complete,

        [Description("Canceled")]
        Canceled
    }
}
