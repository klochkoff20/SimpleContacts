using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleContacts.Common.Enums;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;
using Z.EntityFramework.Plus;

namespace SimpleContacts.DAL.Implementations
{
    public class VacancyRepository : Repository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Vacancy>> GetAllVacanciesAsync()
        {
            var query = Entities
                    .IncludeOptimized(e => e.Department)
                    .IncludeOptimized(e => e.Project)
                    .IncludeOptimized(e => e.ResponsibleUser);

            var vacancies = await Task.Run(() => query.ToList());
            return vacancies;
        }

        public async Task<IEnumerable<Vacancy>> GetAllVacanciesSortedAsync(string order, VacancySortField field, string filter)
        {
            var query = Entities
                    .IncludeOptimized(e => e.Department)
                    .IncludeOptimized(e => e.Project)
                    .IncludeOptimized(e => e.ResponsibleUser)
                    .Where(e => e.Status < VacancyStatus.Complete);

            var vacancies = new List<Vacancy>();

            if (!String.IsNullOrEmpty(filter))
            {
                query = query.Where(e => e.Name.Contains(filter)
                                      || e.Department.Name.StartsWith(filter)
                                      || e.Project.Name.StartsWith(filter)
                                      || e.ResponsibleUser.LastName.StartsWith(filter));
            }

            if (field != VacancySortField.NoSort)
            {
                if (order == "asc")
                    query = query.OrderByDynamic(e => $"e.{Enum.GetName(typeof(VacancySortField), field)}");
                else
                    query = query.OrderByDescendingDynamic(e => $"e.{Enum.GetName(typeof(VacancySortField), field)}");
            }

            vacancies = await Task.Run(() => query.ToList());
            return vacancies;
        }

        private IQueryable<Vacancy> IncludeAllDependencies(IQueryable<Vacancy> query)
        {
            return query
                    .IncludeOptimized(e => e.Department)
                    .IncludeOptimized(e => e.Project)
                    .IncludeOptimized(e => e.CreatedUser)
                    .IncludeOptimized(e => e.UpdatedUser)
                    .IncludeOptimized(e => e.ResponsibleUser)
                    .IncludeOptimized(e => e.Comments)
                    .IncludeOptimized(e => e.VacanciesAttachments)
                        .IncludeOptimized(e => e.VacanciesAttachments.Select(s => s.Vacancy))
                    .IncludeOptimized(e => e.CandidatesVacancies)
                        .IncludeOptimized(e => e.CandidatesVacancies.Select(s => s.Candidate));
        }
    }
}
