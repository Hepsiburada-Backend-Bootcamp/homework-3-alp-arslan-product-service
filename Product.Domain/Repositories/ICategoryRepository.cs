using System.Collections.Generic;
using System.Threading.Tasks;
using ProductNS.Domain.Models;

namespace ProductNS.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<int> AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> FindByIdAsync(int id);
    }
}