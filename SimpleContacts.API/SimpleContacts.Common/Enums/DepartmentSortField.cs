using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum DepartmentSortField
    {
        [Description("NoSort")]
        NoSort = -1,

        [Description("CreatedAt")]
        CreatedAt,

        [Description("Name")]
        Name,

        [Description("Status")]
        Status,

        [Description("ResponsibleUser")]
        ResponsibleUser = 5
    }
}
