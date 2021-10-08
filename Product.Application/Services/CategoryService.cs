using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductNS.Application.Dtos;
using ProductNS.Application.Exceptions;
using ProductNS.Domain.Models;
using ProductNS.Domain.Repositories;

namespace ProductNS.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CategoryDto>> GetCategories(string sortParameter)
        {
            List<Category> categories = await _repository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(sortParameter))
                throw new ArgumentNullException();

            categories = sortParameter switch
            {
                "id" => categories.OrderBy(c => c.Id).ToList(),
                "name" => categories.OrderBy(c => c.Name).ToList(),
                _ => categories
            };

            return _mapper.Map<List<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAdmin()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _repository.FindByIdAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<int> CreateCategory(CreateCategoryDto dto)
        {
            Category category = _mapper.Map<CreateCategoryDto, Category>(dto);
            category.DateOfCreation = DateTime.Now;
            return await _repository.AddAsync(category);
        }
    }
}