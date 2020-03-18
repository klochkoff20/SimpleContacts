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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {   
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var query = Entities
                    .IncludeOptimized(e => e.Projects)
                    .IncludeOptimized(e => e.Vacancies);

            var departments = await Task.Run(() => query.ToList());
            return departments;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsSortedAsync(string order, DepartmentSortField field, string filter)
        {
            var query = Entities
                    .IncludeOptimized(e => e.Projects)
                    .IncludeOptimized(e => e.Vacancies);

            var departments = new List<Department>();

            if(!String.IsNullOrEmpty(filter))
            {
                query = query.Where(e => e.Name.Contains(filter)
                                      || e.Vacancies.Any(v => v.Name.Contains(filter))
                                      || e.Projects.Any(p => p.Name.Contains(filter)));
            }

            if(field != DepartmentSortField.NoSort)
            {
                if (order == "asc")
                    query = query.OrderByDynamic(e => $"e.{Enum.GetName(typeof(DepartmentSortField), field)}");
                else
                    query = query.OrderByDescendingDynamic(e => $"e.{Enum.GetName(typeof(DepartmentSortField), field)}");
            }

            departments = await Task.Run(() => query.ToList());
            return departments;
        }
    }
}
