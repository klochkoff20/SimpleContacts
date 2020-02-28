using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateSortField
    {
        [Description("NoSort")]
        NoSort = 0,

        [Description("Contact")]
        Contact,

        [Description("DesiredPosition")]
        DesiredPosition,

        [Description("ResponsibleUser")]
        ResponsibleUser,

        [Description("AddingDate")]
        AddingDate,

        [Description("AddingSource")]
        AddingSource
    }
}
