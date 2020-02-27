using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum Currency : byte
    {
        [Description("USD")]
        USD = 0,

        [Description("EUR")]
        EUR,

        [Description("UAH")]
        UAH,

        [Description("CHF")]
        CHF
    }
}
