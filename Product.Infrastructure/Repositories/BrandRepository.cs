using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductNS.Domain.Models;
using ProductNS.Domain.Repositories;
using ProductNS.Infrastructure.Context;

namespace ProductNS.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        
        private readonly ProductContext _context;
        public BrandRepository(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<int> AddAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> FindByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }
    }
}