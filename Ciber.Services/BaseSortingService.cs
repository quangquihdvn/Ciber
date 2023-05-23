using Ciber.Models.Entities.Bases;
using System.Linq;
using Ciber.Infrastructure.Extensions;

namespace Ciber.Services
{
    /// <summary>
    /// Basse sorting and paging
    /// </summary>
    public class BaseSortingService
    {
        /// <summary>
        /// Paging and sorting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchRequest"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        protected IQueryable<T> PagingAndSorting<T>(PagingQuery searchRequest, IQueryable<T> query)
        {
            if (searchRequest == null)
            {
                return query;
            }
            if (!string.IsNullOrEmpty(searchRequest.OrderBy)
                && searchRequest.GetFieldMapping().ContainsKey(searchRequest.OrderBy.ToLower()))
            {
                string sortField = searchRequest.GetFieldMapping()[searchRequest.OrderBy.ToLower()];
                if (searchRequest.OrderByDesc)
                {
                    query = query.OrderByDescending(sortField);
                }
                else
                {
                    query = query.OrderBy(sortField);
                }
                
            }
            if (searchRequest.PageSize > 0)
            {
                return query
                    .Skip((searchRequest.PageIndex - 1) * searchRequest.PageSize)
                    .Take(searchRequest.PageSize);
            }

            return query;
        }
    }
}
