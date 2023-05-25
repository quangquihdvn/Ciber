using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Request;
using Ciber.Models.ViewModels;
using Ciber.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly CiberDbContext _context;
        public OrderController(
            IOrderService orderService,
            CiberDbContext context,
            IProductService productService)
        {
            _orderService = orderService;
            _context = context;
            _productService = productService;
        }

        public async Task<IActionResult> Index(
            string searchTerm,
            string orderBy,
            bool orderByDesc,
            int pageIndex = 1
            )
        {
            ViewData["orderByDescNextPage"] = orderByDesc;
            ViewData["orderByDescValue"] = !orderByDesc;
            ViewData["orderByValue"] = orderBy;
            var request = new OrderListRequest
            {
                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                PageSize = 5,
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
            var quantity = await _productService.GetProductQuanttiy(request.ProductId);
            if (request.Amount > quantity) 
            {
                TempData["warning"] = string.Format("Số lượng không được vượt quá {0}", quantity);
                return RedirectToAction("Index", "Order");
            }
            await _orderService.AddNewOrder(request);
            return RedirectToAction("Index", "Order");
        }
    }
}
