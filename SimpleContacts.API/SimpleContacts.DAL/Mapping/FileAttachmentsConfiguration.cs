using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class FileAttachmentsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<FileAttachment>().HasOne(e => e.AddedUser)
                   .WithMany(e => e.AddedFiles)
                   .HasForeignKey(e => e.AddedBy)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FileAttachment>().Property(e => e.Id).IsRequired();
            builder.Entity<FileAttachment>().Property(e => e.Name).IsRequired().HasMaxLength(256);
        }
    }
}
