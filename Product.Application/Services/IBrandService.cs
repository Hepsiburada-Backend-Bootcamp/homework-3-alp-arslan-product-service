using ProductNS.Application.Dtos;
using ProductNS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductNS.Application.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetBrands(string sortParameter);
        Task<IEnumerable<Brand>> GetBrandsAdmin();
        Task<BrandDto> GetBrand(int id);
        Task<int> CreateBrand(CreateBrandDto dto);
    }
}
