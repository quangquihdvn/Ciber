using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Request;
using Ciber.Models.ViewModels;
using Ciber.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly CiberDbContext _context;
        public OrderController(IOrderService orderService,
            CiberDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        public async Task<IActionResult> Index(
            string searchTerm,
            string orderBy,
            string orderByDesc,
            string currentFilter,
            int pageIndex = 1
            )
        {
            ViewData["orderByValue"] = orderBy;
            ViewData["orderByDescValue"] = orderByDesc;

            if (!string.IsNullOrEmpty(currentFilter))
            {
                if (currentFilter == "acs")
                {
                    orderByDesc = null;
                    ViewData["CurrentFilter"] = "desc";
                }
                else
                {
                    orderBy = null;
                    ViewData["CurrentFilter"] = "acs";
                }

            }
            else
            {
                ViewData["CurrentFilter"] = "acs";
            }

            var request = new OrderListRequest
            {
                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                PageSize = 10,
                OrderBy = orderBy,
                OrderByDesc = orderByDesc
            };

            var data = await _orderService.GetPaging(request);

            this.ViewBag.Pager = data.Paging;
            this.ViewBag.Products = _context.Products.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });
            this.ViewBag.Customers = _context.Customers.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });
            var model = data.Data.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrderRequest request)
        {
            await _orderService.AddNewOrder(request);
            return RedirectToAction("Index", "Order");
        }
    }
}
