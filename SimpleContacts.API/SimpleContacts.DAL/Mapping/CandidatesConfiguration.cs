using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class CandidatesConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Candidate>().HasOne(e => e.Contact)
                   .WithMany(e => e.Candidates)
                   .HasForeignKey(e => e.ContactId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Candidate>().HasOne(e => e.ResponcibleUser)
                   .WithMany(e => e.ResponcibleCandidates)
                   .HasForeignKey(e => e.ResponsibleBy)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Candidate>().Property(e => e.Id).IsRequired();
            builder.Entity<Candidate>().Property(e => e.Location).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.Industry).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.CurrentWork).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.CurrentPosition).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.Education).HasMaxLength(512);
            builder.Entity<Candidate>().Property(e => e.HomePage).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.Skills).HasMaxLength(1024);
            builder.Entity<Candidate>().Property(e => e.Description).HasMaxLength(2048);

            builder.Entity<Skill>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(e => e.Name).HasMaxLength(128);

            builder.Entity<Tag>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(e => e.Name).HasMaxLength(256);
        }
    }
}
