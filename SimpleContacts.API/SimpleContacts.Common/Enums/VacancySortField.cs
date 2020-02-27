using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancySortField
    {
        [Description("NoSort")]
        NoSort = 0,

        [Description("Name")]
        Name,

        [Description("Department")]
        Department,

        [Description("Project")]
        Project,

        [Description("Priority")]
        Priority,

        [Description("TargetDate")]
        TargetDate,

        [Description("Salary")]
        SalaryMin,

        [Description("Responsible")]
        ResponsibleUser,

        [Description("Status")]
        Status
    }
}
