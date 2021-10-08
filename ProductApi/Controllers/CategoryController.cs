using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductNS.Application.Dtos;
using ProductNS.Application.Exceptions;
using ProductNS.Application.Services;
using ProductNS.Domain.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery]string sortBy = "id")
        {
            return Ok(await _service.GetCategories(sortBy));
        }

        //This endpoint is for testing purposes.
        //No endpoint should pass the model by itself.
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAdmin()
        {
            return Ok(await _service.GetCategoriesAdmin());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute] int id)
        {
            try
            {
                return Ok(await _service.GetCategory(id));
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            try
            {
                int id = await _service.CreateCategory(dto);
                //TODO: Refactor hard coded route
                return Created("api/v1/categories/" + id, "api/v1/categories/" + id);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}