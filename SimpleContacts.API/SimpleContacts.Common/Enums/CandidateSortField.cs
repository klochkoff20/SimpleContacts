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

        [Description("Skills")]
        Skills,

        [Description("ResponsibleUser")]
        ResponsibleUser,

        [Description("AddingDate")]
        AddingDate,

        [Description("AddingSource")]
        AddingSource
    }
}
