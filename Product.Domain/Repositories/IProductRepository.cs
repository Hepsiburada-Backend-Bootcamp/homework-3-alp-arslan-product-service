using ProductNS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductNS.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> FindByIdAsync(int id);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
        Task<bool> AnyAsync(int id);
    }
}
