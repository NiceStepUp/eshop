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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET api/orderItem
        [HttpGet]
        public async Task<OrderItemDto> Get(int id)
        {
            return await _orderItemService.GetById(id);
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderItemService.GetAll());
        }

        // POST api/orderItem
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItemDto orderItemDto)
        {            
            return Ok(await _orderItemService.Add(orderItemDto));
        }


        // PUT api/orderItem
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderItemDto orderItemDto)
        {
            await _orderItemService.Update(orderItemDto);
            return Ok(orderItemDto);
        }


        // PUT api/orderItem
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OrderItemDto orderItemDto)
        {
            await _orderItemService.Delete(orderItemDto);
            return Ok(orderItemDto);
        }
    }
}