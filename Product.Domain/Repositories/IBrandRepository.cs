using System.Collections.Generic;
using System.Threading.Tasks;
using ProductNS.Domain.Models;

namespace ProductNS.Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<int> AddAsync(Brand brand);
        Task<List<Brand>> GetAllAsync();
        Task<Brand> FindByIdAsync(int id);
    }
}