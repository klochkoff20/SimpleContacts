using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class CommentsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Comment>().HasOne(e => e.Department)
                    .WithMany(e => e.Comments)
                    .HasForeignKey(e => e.DepartmentId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>().HasOne(e => e.Candidate)
                   .WithMany(e => e.Comments)
                   .HasForeignKey(e => e.CandidateId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>().HasOne(e => e.Vacancy)
                   .WithMany(e => e.Comments)
                   .HasForeignKey(e => e.VacancyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>().HasOne(e => e.User)
                   .WithMany(e => e.Comments)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>().Property(e => e.Id).IsRequired();
            builder.Entity<Comment>().Property(e => e.Message).IsRequired().HasMaxLength(2048);
        }
    }
}
