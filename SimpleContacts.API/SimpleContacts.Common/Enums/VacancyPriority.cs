using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancyPriority : byte
    {
        [Description("Low")]
        Low = 0,

        [Description("Medium")]
        Medium,

        [Description("High")]
        High,

        [Description("Highest")]
        Highest
    }
}
