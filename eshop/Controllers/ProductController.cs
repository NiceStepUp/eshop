using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eshop.Common.Service.Business;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET api/product
        [HttpGet]
        public async Task<ProductDto> Get(int id)
        {
            return _mapper.Map<ProductDto>(await _productService.GetById(id));
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(await _productService.GetAll()));
        }

        // POST api/product
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {            
            await _productService.Add(productDto);
            return Ok(productDto);
        }


        // PUT api/product
        [HttpPut, Authorize]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {            
            await _productService.Update(productDto);
            return Ok(productDto);
        }


        // PUT api/product
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}