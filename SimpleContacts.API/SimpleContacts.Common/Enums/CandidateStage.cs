using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CandidateStage : byte
    {
        [Description("Short list")]
        ShortList = 0,

        [Description("Interview")]
        Interview,

        [Description("Not a fit")]
        NotFit,

        [Description("Tech interview")]
        TechInterview,

        [Description("Offer sent")]
        OfferSent,

        [Description("Offer declined")]
        OfferDeclined,

        [Description("Offer accepted")]
        OfferAccepted
    }
}
