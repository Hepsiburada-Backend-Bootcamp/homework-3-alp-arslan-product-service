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
    [Route("api/v1/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService brandService)
        {
            _service = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands([FromQuery]string sortBy = "id")
        {
            return Ok(await _service.GetBrands(sortBy));
        }

        //This endpoint is for testing purposes.
        //No endpoint should pass the model by itself.
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrandsAdmin()
        {
            return Ok(await _service.GetBrandsAdmin());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetBrand([FromRoute] int id)
        {
            try
            {
                return Ok(await _service.GetBrand(id));
            }
            catch (BrandNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> CreateBrand([FromBody] CreateBrandDto dto)
        {
            try
            {
                int id = await _service.CreateBrand(dto);
                //TODO: Refactor hard coded route
                return Created("api/v1/brands/" + id, "api/v1/brands/" + id);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}