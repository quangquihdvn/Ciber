using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.ViewModels;
using Ciber.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Test.ServiceTest
{
    [TestClass]
    public class OrderServiceTest
    {
        private CiberDbContext _context;
        private IOrderService _orderService;

        public OrderServiceTest()
        {
            Initialize();
        }
        public void Initialize()
        {
            _context = new CiberDbContext();
            _orderService = new OrderService(_context);
        }

        [TestMethod]
        public void GetAllOrders_Test()
        {
            var request = new OrderListRequest
            {
                SearchTerm = "",
                PageIndex = 1,
                OrderBy = "ProductName"
            };
            var result = _orderService.GetPaging(request);
            var count = result.Result.Count;
            Assert.AreEqual(10, count);
        }
    }
}
