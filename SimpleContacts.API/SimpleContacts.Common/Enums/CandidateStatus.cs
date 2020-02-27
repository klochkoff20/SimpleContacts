using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateStatus : byte
    {
        [Description("Active")]
        Active = 0,

        [Description("Not interested")]
        NotInterested,

        [Description("Passive search")]
        PassiveSearch,

        [Description("Freelancer")]
        Freelancer,

        [Description("Deleted")]
        Deleted
    }
}
