using System.Threading.Tasks;
using System.Collections.Generic;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.DAL.Abstractions
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<IEnumerable<Department>> GetAllDepartmentsSortedAsync(string order, DepartmentSortField field, string filter);
    }
}
