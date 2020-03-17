using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class ProjectsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Project>().HasOne(e => e.Department)
                   .WithMany(e => e.Projects)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>().Property(e => e.Id).IsRequired();
            builder.Entity<Project>().Property(e => e.Name).IsRequired().HasMaxLength(128);
        }
    }
}
