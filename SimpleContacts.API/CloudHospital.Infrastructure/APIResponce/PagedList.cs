using System.Collections.Generic;

namespace SimpleContacts.Infrastructure.APIResponce
{
    public class PagedList<TEntity>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalItems { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
