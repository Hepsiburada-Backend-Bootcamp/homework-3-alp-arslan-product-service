using ProductNS.Application.Dtos;
using ProductNS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductNS.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories(string sortParameter);
        Task<IEnumerable<Category>> GetCategoriesAdmin();
        Task<CategoryDto> GetCategory(int id);
        Task<int> CreateCategory(CreateCategoryDto dto);
    }
}
