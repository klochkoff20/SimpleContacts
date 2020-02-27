using System.ComponentModel;

namespace SimpleContacts.Common.Enums
{
    public enum CommentType : byte
    {
        [Description("Comment")]
        Comment = 0,

        [Description("ActivityLog")]
        ActivityLog
    }
}
