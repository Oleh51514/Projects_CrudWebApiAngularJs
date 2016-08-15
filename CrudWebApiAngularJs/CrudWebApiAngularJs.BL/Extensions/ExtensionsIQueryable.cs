using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.BL.Extensions
{
    public static class ExtensionsIQueryable
    {
        public static IQueryable<T> AndFilter<T>(this IQueryable<T> source, string[] filters) where T : class
        {
            string filterQuery = filters.Any() ? string.Join(" AND ", filters) : "True";

            return source.Where(filterQuery);
        }

        public static IEnumerable<T> GetPage<T>(this IQueryable<T> source, string[] sort, int skip, int pageSize) where T : class
        {
            string sortQuery = sort.Any() ? string.Join(", ", Array.ConvertAll(sort, x => x.ToString())) : "id asc";
            return source.OrderBy(sortQuery).Skip(skip).Take(pageSize);
        }
    }
}
