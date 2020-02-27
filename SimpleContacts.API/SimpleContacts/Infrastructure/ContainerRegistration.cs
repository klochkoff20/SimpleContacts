using Autofac;
using SimpleContacts.DAL;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.DAL.Implementations;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.Services.Implementations;

namespace SimpleContacts.Web.Infrastructure
{
    public static class ContainerRegistration
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AccountManager>().As<IAccountManager>();
            builder.RegisterType<CandidateService>().As<ICandidateService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<VacancyService>().As<IVacancyService>();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CandidateRepository>().As<ICandidateRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<VacancyRepository>().As<IVacancyRepository>();
        }
    }
}
