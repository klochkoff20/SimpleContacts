using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateExperience : byte
    {
        [Description("No experience")]
        NoExperience = 0,

        [Description("Least 1 year")]
        LeastOneYear,

        [Description("1-2 years")]
        OneTwoYears,

        [Description("2-3 years")]
        TwoThreeYears,

        [Description("3-4 years")]
        ThreeFourYears,

        [Description("4-5 years")]
        FourFiveYears,

        [Description("More than 5 years")]
        MoreThanFiveYears
    }
}
