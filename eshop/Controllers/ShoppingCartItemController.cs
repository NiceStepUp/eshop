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
    [ApiController, Authorize]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemService _shoppingCartItemService;
        

        public ShoppingCartItemController(IShoppingCartItemService shoppingCartService)
        {
            _shoppingCartItemService = shoppingCartService;
        }

        // GET api/shoppingCartItem
        [HttpGet]
        public async Task<ShoppingCartItemDto> Get(Guid id, int productId)
        {
            return await _shoppingCartItemService.GetByIdAndProductId(id, productId);
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shoppingCartItemService.GetAll());
        }

        // POST api/shoppingCartItem
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCartItemDto shoppingCartDto)
        {
            await _shoppingCartItemService.Add(shoppingCartDto);
            return Ok();
        }


        // PUT api/shoppingCartItem
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShoppingCartItemDto shoppingCartDto)
        {
            await _shoppingCartItemService.Update(shoppingCartDto);
            return Ok();
        }


        // PUT api/shoppingCartItem
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ShoppingCartItemDto shoppingCartDto)
        {
            await _shoppingCartItemService.Delete(shoppingCartDto);
            return Ok();
        }
    }
}