using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.DAL.Implementations
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
