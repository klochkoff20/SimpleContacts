using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Z.EntityFramework.Plus;
using SimpleContacts.Common.Enums;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Implementations
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            var query = Entities
                    .IncludeOptimized(e => e.Contact)
                    .IncludeOptimized(e => e.ResponsibleUser);

            var candidates = await Task.Run(() => query.ToList());
            return candidates;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesSortedAsync(string order, CandidateSortField field, string filter)
        {
            var query = Entities
                    .IncludeOptimized(e => e.Contact)
                    .IncludeOptimized(e => e.ResponsibleUser);

            var candidates = new List<Candidate>();

            if(!string.IsNullOrEmpty(filter))
            {
                query = query.Where(e => e.Contact.FirstName.Contains(filter)
                                      || e.Contact.LastName.Contains(filter)
                                      || e.DesiredPosition.Contains(filter)
                                      || e.ResponsibleUser.LastName.Contains(filter));
            }

            if(field != CandidateSortField.NoSort)
            {
                if (order == "asc")
                    query = query.OrderByDynamic(e => $"e.{Enum.GetName(typeof(CandidateSortField), field)}");
                else
                    query = query.OrderByDescendingDynamic(e => $"e.{Enum.GetName(typeof(CandidateSortField), field)}");
            }

            candidates = await Task.Run(() => query.ToList());
            return candidates;
        }
    }
}
