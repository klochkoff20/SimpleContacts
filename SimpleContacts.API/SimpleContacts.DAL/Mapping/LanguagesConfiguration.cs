using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class LanguagesConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Language>().Property(e => e.Id).IsRequired();
            builder.Entity<Language>().Property(e => e.Name).IsRequired().HasMaxLength(32);
        }
    }
}
