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

            builder.Entity<CandidatesTags>().HasKey(e => new { e.CandidateId, e.TagId });
            builder.Entity<CandidatesTags>().HasOne(e => e.Candidate)
                   .WithMany(e => e.CandidatesTags)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<CandidatesTags>().HasOne(e => e.Tag)
                   .WithMany(e => e.CandidatesTags)
                   .HasForeignKey(e => e.TagId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<CandidatesAttachments>().HasKey(e => new { e.CandidateId, e.FileId });
            builder.Entity<CandidatesAttachments>().HasOne(e => e.Candidate)
                   .WithMany(e => e.CandidatesAttachments)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<CandidatesAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.CandidatesAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<CandidatesVacancies>().HasKey(e => new { e.CandidateId, e.VacancyId });
            builder.Entity<CandidatesVacancies>().HasOne(e => e.Candidate)
                   .WithMany(e => e.CandidatesVacancies)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<CandidatesVacancies>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.CandidatesVacancies)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DepartmentsContacts>().HasKey(e => new { e.DepartmentId, e.ContactId });
            builder.Entity<DepartmentsContacts>().HasOne(e => e.Contact)
                   .WithMany(e => e.ContactsDepartments)
                   .HasForeignKey(e => e.ContactId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<DepartmentsContacts>().HasOne(e => e.Department)
                   .WithMany(e => e.ContactsDepartments)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DepartmentsAttachments>().HasKey(e => new { e.DepartmentId, e.FileId });
            builder.Entity<DepartmentsAttachments>().HasOne(e => e.Department)
                   .WithMany(e => e.DepartmentsAttachments)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<DepartmentsAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.DepartmentsAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VacanciesAttachments>().HasKey(e => new { e.VacancyId, e.FileId });
            builder.Entity<VacanciesAttachments>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.VacanciesAttachments)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<VacanciesAttachments>().HasOne(e => e.FileAttachment)
                   .WithMany(e => e.VacanciesAttachments)
                   .HasForeignKey(e => e.FileId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
