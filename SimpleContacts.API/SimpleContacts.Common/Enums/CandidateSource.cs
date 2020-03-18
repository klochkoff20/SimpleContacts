using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateSource : byte
    {
        [Description("AddedManually")]
        AddedManually = 0,

        [Description("Recommended candidate")]
        RecommendedCandidate,

        [Description("CV")]
        CV,

        [Description("Import from email")]
        ImportFromEmail,

        [Description("JobBoard")]
        JobBoard,

        [Description("LinkedIn")]
        LinkedIn
    }
}
