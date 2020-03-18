using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateSortField
    {
        [Description("NoSort")]
        NoSort = 0,

        [Description("Contact")]
        LastName,

        [Description("DesiredPosition")]
        DesiredPosition,

        [Description("Level")]
        Level,

        [Description("Skills")]
        Skills,

        [Description("AddingDate")]
        AddingDate,

        [Description("AddingSource")]
        Source
    }
}
