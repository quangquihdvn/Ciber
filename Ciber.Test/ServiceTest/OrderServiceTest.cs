using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.ViewModels;
using Ciber.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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
            var categories = TestDataHelper.GetFakeCategories();
            var products = TestDataHelper.GetFakeProducts();
            var customers = TestDataHelper.GetFakeCustomers();
            var orders = TestDataHelper.GetFakeOrders();
            // Insert seed data into the database using one instance of the context
            var context = TestDataHelper.GetAppDbContext();
            context.Categories.AddRange(categories);
            context.Products.AddRange(products);
            context.Customers.AddRange(customers);
            context.Orders.AddRange(orders);

            context.SaveChanges();
            _orderService = new OrderService(context);
        }

        [TestMethod]
        public async Task Without_Search_OrderService_GetPaging()
        {
            var request = new OrderListRequest
            {
                SearchTerm = "",
                PageIndex = 1,
                OrderBy = "ProductName",
                PageSize = 10,
            };
            var result = await _orderService.GetPaging(request);
            var count = result.Data.Count;
            Assert.AreEqual(10, count);
        }

        [TestMethod]
        public async Task Search_OrderService_GetPaging()
        {
            var request = new OrderListRequest
            {
                SearchTerm = "Cat1",
                PageIndex = 1,
                OrderBy = "ProductName",
                PageSize = 10,
            };
            var result = await _orderService.GetPaging(request);
            var check = result.Data.All(x => x.CategoryName.ToLower().Contains("cat1"));
            Assert.IsTrue(check);
        }
    }
}
