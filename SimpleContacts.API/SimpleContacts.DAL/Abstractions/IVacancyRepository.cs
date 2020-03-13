using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleContacts.DAL.Abstractions
{
    public interface IVacancyRepository : IRepository<Vacancy>
    {
        Task<Vacancy> GetVacancyById(Guid id);
        Task<IEnumerable<Vacancy>> GetAllVacanciesAsync();
        Task<IEnumerable<Vacancy>> GetAllVacanciesSortedAsync(string order, VacancySortField field, string filter);
    }
}
