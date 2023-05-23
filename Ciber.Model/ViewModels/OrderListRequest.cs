using Ciber.Models.Entities.Bases;
using System.Collections.Generic;

namespace Ciber.Models.ViewModels
{
    public class OrderListRequest : PagingQuery
    {
        public override Dictionary<string, string> GetFieldMapping()
        {
            return new Dictionary<string, string>
            {
                { "name", "Name" },
                { "productname", "ProductName" },
                { "categoryname", "CategoryName" },
                { "orderdate", "OrderDate" },
                { "customername", "CustomerName" }
            };
        }
    }
}
