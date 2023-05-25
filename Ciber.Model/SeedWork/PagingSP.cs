using System;

namespace Ciber.Model.SeedWork
{
    public class PagingSP
    {
        public PagingSP() { }
        public PagingSP(int totalCount, int pageIndex, int pageSize)
        {
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = totalPages;
        }

        public int TotalCount { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
    }
}
