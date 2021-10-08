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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BrandDto>> GetBrands(string sortParameter)
        {
            List<Brand> brands = await _repository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(sortParameter))
                throw new ArgumentNullException();

            brands = sortParameter switch
            {
                "id" => brands.OrderBy(c => c.Id).ToList(),
                "name" => brands.OrderBy(c => c.Name).ToList(),
                _ => brands
            };

            return _mapper.Map<List<Brand>, IEnumerable<BrandDto>>(brands);
        }

        public async Task<IEnumerable<Brand>> GetBrandsAdmin()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BrandDto> GetBrand(int id)
        {
            var brand = await _repository.FindByIdAsync(id);

            if (brand == null)
            {
                throw new BrandNotFoundException(id);
            }

            return _mapper.Map<Brand, BrandDto>(brand);
        }

        public async Task<int> CreateBrand(CreateBrandDto dto)
        {
            Brand brand = _mapper.Map<CreateBrandDto, Brand>(dto);
            brand.DateOfCreation = DateTime.Now;
            return await _repository.AddAsync(brand);
        }
    }
}