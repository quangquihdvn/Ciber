using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Entities;
using Ciber.Models.Entities.Bases;
using Ciber.Models.Request;
using Ciber.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Services
{
    public interface IOrderService
    {
        Task<PagingResultSP<OrderListPagingModel>> GetPaging(OrderListRequest request);
        Task<bool> AddNewOrder(AddOrderRequest request);
    }
    public class OrderService : BaseSortingService, IOrderService
    {
        private readonly CiberDbContext _context;
        public OrderService(CiberDbContext context)
        {
            _context = context;
        }
        public async Task<PagingResultSP<OrderListPagingModel>> GetPaging(OrderListRequest request)
        {
            var query = _context.Orders
                .Select(x => new OrderListPagingModel
                {
                    Name = x.Name,
                    ProductName = x.Product.Name,
                    CategoryName = x.Product.Category.Name,
                    CustomerName = x.Customer.Name,
                    OrderDate = x.OrderDate,
                    Amount = x.Amount
                });

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                request.SearchTerm = request.SearchTerm.ToLower();
                query = query.Where(x => x.ProductName.ToLower().Contains(request.SearchTerm) ||
                                         x.CategoryName.ToLower().Contains(request.SearchTerm) ||
                                         x.CustomerName.ToLower().Contains(request.SearchTerm) ||
                                         x.Name.ToLower().Contains(request.SearchTerm));
            }

            var totalRow = await query.CountAsync();
            var queryPaging = PagingAndSorting(request, query);
            return await PagingResultSP<OrderListPagingModel>.CreateAsyncLinq(queryPaging, totalRow, request.PageIndex, request.PageSize);

        }

        public async Task<bool> AddNewOrder(AddOrderRequest request)
        {
            var order = new Order
            {
                Name = request.OrderName,
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                Amount = request.Amount,
            };

            _context.Add(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
