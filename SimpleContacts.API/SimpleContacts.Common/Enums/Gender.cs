using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum Gender : byte
    {
        [Description("Male")]
        Male = 0,

        [Description("Female")]
        Female
    }
}
