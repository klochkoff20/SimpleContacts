using Microsoft.EntityFrameworkCore;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Mapping
{
    internal class CandidatesConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Candidate>().Property(e => e.Id).IsRequired();
            builder.Entity<Candidate>().Property(e => e.FirstName).IsRequired().HasMaxLength(64);
            builder.Entity<Candidate>().Property(e => e.LastName).IsRequired().HasMaxLength(64);
            builder.Entity<Candidate>().Property(e => e.Location).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.Industry).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.CurrentWork).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.CurrentPosition).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.Education).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.DesiredPosition).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.PhoneNumber).HasMaxLength(32);
            builder.Entity<Candidate>().Property(e => e.Email).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.Skype).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.LinkedIn).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.Telegram).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.Facebook).HasMaxLength(128);
            builder.Entity<Candidate>().Property(e => e.HomePage).HasMaxLength(256);
            builder.Entity<Candidate>().Property(e => e.Skills).HasMaxLength(1024);
            builder.Entity<Candidate>().Property(e => e.Skills).HasMaxLength(2048);
            builder.Entity<Candidate>().Property(e => e.Description).HasMaxLength(2048);

            builder.Entity<Skill>().Property(e => e.Id).IsRequired();
            builder.Entity<Skill>().Property(e => e.Name).HasMaxLength(128);
        }
    }
}
