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
    public class ShoppingCartController : ControllerBase
    {   
        private readonly IShoppingCartService _shoppingCartService;        

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // GET api/shoppingCart
        [HttpGet]
        public async Task<ShoppingCartDto> Get(Guid id)
        {
            return await _shoppingCartService.GetById(id);
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shoppingCartService.GetAll());
        }

        // POST api/shoppingCart
        // [HttpPost, Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCartDto shoppingCartDto)
        {
            var newShoppingCart = await _shoppingCartService.Add(shoppingCartDto);
            return Ok(newShoppingCart);
        }


        // PUT api/shoppingCart
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShoppingCartDto shoppingCartDto)
        {   
            shoppingCartDto = await _shoppingCartService.Update(shoppingCartDto);
            return Ok(shoppingCartDto);
        }


        // PUT api/shoppingCart
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete([FromBody] ShoppingCartDto shoppingCartDto)
        {   
            await _shoppingCartService.Delete(shoppingCartDto);
            return Ok();
        }
    }
}