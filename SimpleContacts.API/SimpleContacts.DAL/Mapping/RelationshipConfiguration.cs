using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class RelationshipConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Role>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Role>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Role>().Property(e => e.Description).HasMaxLength(128);

            builder.Entity<CandidatesAttachments>().HasKey(e => new { e.CandidateId, e.FileId });
            builder.Entity<CandidatesAttachments>().HasOne(e => e.Candidate)
                   .WithMany(e => e.CandidatesAttachments)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CandidatesAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.CandidatesAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CandidatesVacancies>().HasKey(e => new { e.CandidateId, e.VacancyId });
            builder.Entity<CandidatesVacancies>().HasOne(e => e.Candidate)
                   .WithMany(e => e.CandidatesVacancies)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CandidatesVacancies>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.CandidatesVacancies)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DepartmentsAttachments>().HasKey(e => new { e.DepartmentId, e.FileId });
            builder.Entity<DepartmentsAttachments>().HasOne(e => e.Department)
                   .WithMany(e => e.DepartmentsAttachments)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<DepartmentsAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.DepartmentsAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<VacanciesAttachments>().HasKey(e => new { e.VacancyId, e.FileId });
            builder.Entity<VacanciesAttachments>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.VacanciesAttachments)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<VacanciesAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.VacanciesAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<VacanciesUsers>().HasKey(e => new { e.VacancyId, e.UserId });
            builder.Entity<VacanciesUsers>().HasOne(e => e.User)
                   .WithMany(e => e.ResponsibleVacancies)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<VacanciesUsers>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.ResponsibleUsers)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<VacancyOnHold>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.VacancyOnHold)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
