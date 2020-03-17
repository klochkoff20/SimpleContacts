using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancyStatus : byte
    {
        [Description("In Progress")]
        InProgress = 0,

        [Description("On Hold")]
        OnHold,

        [Description("Complete")]
        Complete,

        [Description("Canceled")]
        Canceled
    }
}
