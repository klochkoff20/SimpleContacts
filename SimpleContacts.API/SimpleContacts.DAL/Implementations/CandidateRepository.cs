using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Implementations
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
