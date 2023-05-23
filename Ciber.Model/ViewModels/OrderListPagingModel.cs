using Ciber.Model.SeedWork;
using Ciber.Models.SeedWork;
using System;

namespace Ciber.Models.ViewModels
{
    public class OrderListPagingModel : BaseExtendEntities
    {
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
