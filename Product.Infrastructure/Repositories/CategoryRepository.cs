using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductNS.Domain.Models;
using ProductNS.Domain.Repositories;
using ProductNS.Infrastructure.Context;

namespace ProductNS.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private readonly ProductContext _context;
        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<int> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}