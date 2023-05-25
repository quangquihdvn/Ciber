using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Services
{
    public interface IProductService
    {
        Task<int> GetProductQuanttiy(Guid productId);
    }

    public class ProductService : IProductService
    {
        private readonly CiberDbContext _context;
        public ProductService(CiberDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetProductQuanttiy(Guid productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return product == null ? 0 : product.Quantity;
        }
    }
}
