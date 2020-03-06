using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum EmploymentType : byte
    {
        [Description("Full time office")]
        FullTimeOffice = 0,

        [Description("Part time office")]
        PartTimeOffice,

        [Description("Full time remote")]
        FullTimeRemote,

        [Description("Part time remote")]
        PartTimeRemote,

        [Description("Freelancer")]
        Freelancer,

        [Description("Consultant")]
        Consultant,

        [Description("Internship")]
        Internship
    }
}
