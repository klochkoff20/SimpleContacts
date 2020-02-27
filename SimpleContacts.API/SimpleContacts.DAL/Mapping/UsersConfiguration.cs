using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class UsersConfiguration
    {
        //public static void Configure(ModelBuilder builder)
        //{
        //    builder.Entity<User>().HasOne(e => e.Role)
        //           .WithMany(e => e.Users)
        //           .HasForeignKey(e => e.RoleId)
        //           .OnDelete(DeleteBehavior.NoAction);
        //    builder.Entity<User>().Property(e => e.Id).IsRequired();
        //    builder.Entity<User>().Property(e => e.UserName).IsRequired().HasMaxLength(128);
        //    builder.Entity<User>().Property(e => e.FirstName).HasMaxLength(64);
        //    builder.Entity<User>().Property(e => e.LastName).HasMaxLength(64);
        //    builder.Entity<User>().Property(e => e.Email).HasMaxLength(128);

        //    builder.Entity<Role>().Property(e => e.Description).HasMaxLength(256);
        //}
    }
}
