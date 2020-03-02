using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class ContactsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Contact>().Property(e => e.Id).IsRequired();
            builder.Entity<Contact>().Property(e => e.FirstName).IsRequired().HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.LastName).IsRequired().HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.PhoneNumber).HasMaxLength(32);
            builder.Entity<Contact>().Property(e => e.Email).HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.Skype).HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.LinkedIn).HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.Telegram).HasMaxLength(128);
            builder.Entity<Contact>().Property(e => e.Facebook).HasMaxLength(128);
        }
    }
}
