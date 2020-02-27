using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleContacts.DAL.Mapping;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidatesAttachments> CandidatesAttachments { get; set; }
        public virtual DbSet<CandidatesLanguages> CandidatesLanguages { get; set; }
        public virtual DbSet<CandidatesSkills> CandidatesSkills { get; set; }
        public virtual DbSet<CandidatesTags> CandidatesTags { get; set; }
        public virtual DbSet<CandidatesVacancies> CandidatesVacancies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentsAttachments> DepartmentsAttachments { get; set; }
        public virtual DbSet<DepartmentsContacts> DepartmentsContacts { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<VacanciesAttachments> VacanciesAttachments { get; set; }
        public virtual DbSet<VacanciesLanguages> VacanciesLanguages { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<FileAttachment> FileAttachments { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CandidatesConfiguration.Configure(builder);
            CommentsConfiguration.Configure(builder);
            ContactsConfiguration.Configure(builder);
            DepartmentsConfiguration.Configure(builder);
            FileAttachmentsConfiguration.Configure(builder);
            LanguagesConfiguration.Configure(builder);
            ProjectsConfiguration.Configure(builder);
            RelationshipConfiguration.Configure(builder);
           // UsersConfiguration.Configure(builder);
            VacanciesConfiguration.Configure(builder);
        }
    }
}
