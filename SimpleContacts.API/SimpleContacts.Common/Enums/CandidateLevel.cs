using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateLevel : byte
    {
        [Description("Trainee")]
        Trainee = 0, 

        [Description("Junior")]
        Junior,

        [Description("Strong Junior")]
        StrongJunior,

        [Description("Middle")]
        Middle,

        [Description("Senior")]
        Senior,
    }
}
