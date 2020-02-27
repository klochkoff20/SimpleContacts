using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum EmploymentType : byte
    {
        [Description("Full time")]
        FullTime = 0,

        [Description("Part time")]
        PartTime,

        [Description("Remote")]
        Remote,

        [Description("Internship")]
        Internship,

        [Description("Project")]
        Project,

        [Description("Temporary")]
        Temporary
    }
}
