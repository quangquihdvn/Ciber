using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ciber.Models.Entities.Bases
{
    public class PagingQuery
    {
        /// <summary>
        /// Init
        /// </summary>
        public PagingQuery()
        {
            PageIndex = 1;
            PageSize = int.MaxValue;
            OrderBy = string.Empty;
            OrderByDesc = string.Empty;
        }

        /// <summary>
        /// Search
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Page size is positive number only")]
        public int PageSize { get; set; }

        /// <summary>
        /// Offset
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Page Index is positive number only")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Order by asc/desc
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Has order by desc
        /// </summary>
        public string OrderByDesc { get; set; }

        /// <summary>
        /// Page offset
        /// </summary>
        public int PageOffset { get { return (PageIndex - 1) * PageSize; } }

        /// <summary>
        /// Sort field
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetFieldMapping()
        {
            return new Dictionary<string, string>();
        }
    }
}
