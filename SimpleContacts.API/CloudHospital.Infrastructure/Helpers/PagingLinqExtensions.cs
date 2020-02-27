using System.Linq;
using System.Collections.Generic;
using SimpleContacts.Infrastructure.APIResponce;

namespace SimpleContacts.Infrastructure.Helpers
{
    public static class PagingLinqExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> allItems, int pageNumber, int pageSize)
        {
            var currentPage = pageNumber <= 0 ? pageNumber : pageNumber - 1;

            return new PagedList<T>
            {
                Items = currentPage < 0 ? allItems : allItems.Skip(currentPage * pageSize).Take(pageSize),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = allItems.Count()
            };
        }

        //public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int pageNumber, int pageSize)
        //{
        //    var currentPage = pageNumber <= 0 ? pageNumber : pageNumber - 1;

        //    return new PagedList<T>
        //    {
        //        Items = currentPage < 0 ? allItems : allItems.Skip(currentPage * pageSize).Take(pageSize),
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalItems = allItems.Count()
        //    };
        //}

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> allItems, int pageNumber, int pageSize, int totalCount)
        {
            var items = allItems.ToList();

            return new PagedList<T>()
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount
            };
        }
    }
}
