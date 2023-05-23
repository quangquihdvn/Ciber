using Ciber.Model.SeedWork;
using Ciber.Models.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Models.Entities.Bases
{
    public class PagingResultSP<T> : List<T> where T : BaseExtendEntities
    {
        public PagingSP Paging { get; set; }
        public IList<T> Data { get; set; }

        public PagingResultSP()
        {
        }

        public PagingResultSP(IList<T> data, int totalCount, int pageIndex, int pageSize)
        {
            Paging = new PagingSP(totalCount, pageIndex, pageSize);
            Data = data;
        }

        public static async Task<PagingResultSP<T>> CreateAsyncSP(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var items = await query.ToListAsync();
            var count = items.FirstOrDefault()?.TotalRows ?? 0;

            return new PagingResultSP<T>(items, count, pageIndex, pageSize);
        }

        public static async Task<PagingResultSP<T>> CreateAsyncLinq(IQueryable<T> query, int totalRow, int pageIndex, int pageSize)
        {
            var items = await query.ToListAsync();
            return new PagingResultSP<T>(items, totalRow, pageIndex, pageSize);
        }
    }
}
