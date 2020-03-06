﻿using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum VacancySortField
    {
        [Description("NoSort")]
        NoSort = -1,

        [Description("Added at")]
        CreatedAt,

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

        [Description("Responsible")]
        ResponsibleUser,

        [Description("Status")]
        Status
    }
}
