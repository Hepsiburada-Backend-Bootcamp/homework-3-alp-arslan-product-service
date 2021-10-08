using AutoMapper;
using ProductNS.Application.Dtos;
using ProductNS.Application.Exceptions;
using ProductNS.Domain.Models;
using ProductNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductNS.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateProduct(CreateProductDto dto)
        {
            Product product = _mapper.Map<CreateProductDto, Product>(dto);
            product.DateOfCreation = product.DateOfLastEdit = DateTime.Now;
            return await _repository.AddAsync(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await _repository.FindByIdAsync(id);
            if (product == null)
                return false;

            await _repository.DeleteAsync(product);
            return true;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _repository.FindByIdAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(string sortParameter)
        {
            List<Product> products = await _repository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(sortParameter))
                throw new ArgumentNullException();

            products = sortParameter switch
            {
                "id" => products.OrderBy(p => p.Id).ToList(),
                "name" => products.OrderBy(p => p.Name).ToList(),
                "price" => products.OrderBy(p => p.Price).ToList(),
                "category" => products.OrderBy(p => p.Category.Id).ToList(),
                _ => products
            };

            return _mapper.Map<List<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<Product>> GetProductsAdmin()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateProduct(int id, UpdateProductDto dto)
        {
            if (id != dto.Id)
                throw new IdDoesNotBelongToProductExcepiton(id, dto.Name);

            bool exists = await _repository.AnyAsync(id);
            if (!exists)
                throw new ProductNotFoundException(id);

            Product product = await _repository.FindByIdAsync(id);
            product = _mapper.Map(dto, product);
            product.DateOfLastEdit = DateTime.Now;
            await _repository.UpdateAsync(product);
        }
    }
}
