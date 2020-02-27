using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancyStatus : byte
    {
        [Description("New")]
        New = 0,

        [Description("On Hold")]
        OnHold,

        [Description("In Progress")]
        InProgress,

        [Description("Payment")]
        Payment,

        [Description("Complete")]
        Complete,

        [Description("Replacement")]
        Replacement,

        [Description("Canceled")]
        Canceled
    }
}
