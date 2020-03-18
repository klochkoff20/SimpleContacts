using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class DepartmentsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Department>().HasOne(e => e.CreatedUser)
                   .WithMany(e => e.CreatedDepartments)
                   .HasForeignKey(e => e.CreatedBy)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Department>().HasMany(e => e.Projects)
                   .WithOne(e => e.Department)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Department>().Property(e => e.Id).IsRequired();
            builder.Entity<Department>().Property(e => e.Name).IsRequired().HasMaxLength(128);
            builder.Entity<Department>().Property(e => e.Location).HasMaxLength(128);
            builder.Entity<Department>().Property(e => e.Email).HasMaxLength(128);
            builder.Entity<Department>().Property(e => e.Phone).HasMaxLength(64);
            builder.Entity<Department>().Property(e => e.Description).HasMaxLength(1024);
        }
    }
}
