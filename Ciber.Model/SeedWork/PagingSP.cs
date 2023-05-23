using System;

namespace Ciber.Model.SeedWork
{
    public class PagingSP
    {
        public PagingSP() { }
        public PagingSP(int totalCount, int pageIndex, int pageSize)
        {
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            int currentPage = pageIndex;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalCount { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
