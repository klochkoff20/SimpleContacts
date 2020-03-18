using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class VacanciesConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Vacancy>().HasOne(e => e.Department)
                   .WithMany(e => e.Vacancies)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vacancy>().HasOne(e => e.CreatedUser)
                   .WithMany(e => e.CreatedVacancies)
                   .HasForeignKey(e => e.CreatedBy)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vacancy>().HasOne(e => e.UpdatedUser)
                   .WithMany(e => e.UpdatedVacancies)
                   .HasForeignKey(e => e.UpdatedBy)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vacancy>().Property(e => e.Id).IsRequired();
            builder.Entity<Vacancy>().Property(e => e.Name).IsRequired().HasMaxLength(128);
            builder.Entity<Vacancy>().Property(e => e.Project).HasMaxLength(128);
            builder.Entity<Vacancy>().Property(e => e.Location).HasMaxLength(128);            
            builder.Entity<Vacancy>().Property(e => e.Requirements).IsRequired().HasMaxLength(2048);
            builder.Entity<Vacancy>().Property(e => e.Description).IsRequired().HasMaxLength(2048);

            builder.Entity<Vacancy>().HasIndex(e => e.Name).HasName("IX_VACANCY_NAME");


        }
    }
}
