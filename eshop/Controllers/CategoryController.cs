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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/category
        [HttpGet]
        public async Task<CategoryDto> Get(int id)
        {
            return await _categoryService.GetById(id);
        }


        //[HttpGet("GetAll"), Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        // POST api/category
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {            
            await _categoryService.Add(categoryDto);
            return Ok();
        }


        // PUT api/category
        [HttpPut, Authorize]
        public async Task<IActionResult> Put([FromBody] CategoryDto categoryDto)
        {
            await _categoryService.Update(categoryDto);
            return Ok();
        }


        // PUT api/category
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}