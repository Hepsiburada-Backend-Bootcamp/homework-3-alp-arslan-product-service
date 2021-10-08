using Microsoft.EntityFrameworkCore;
using ProductNS.Domain.Models;
using ProductNS.Domain.Repositories;
using ProductNS.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductNS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }
    }
}
