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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/order
        [HttpGet]
        public async Task<OrderDto> Get(int id)
        {
            return await _orderService.GetById(id);
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        // GET api/getOrdersByUserId
        [HttpGet("GetOrdersByUserId")]
        public async Task<IActionResult> GetOrdersByUserId(string id)
        {
            return Ok(await _orderService.GetOrdersByUserId(id));
        }

        // POST api/order
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto orderDto)
        {
            await _orderService.Add(orderDto);
            return Ok(orderDto);
        }


        // PUT api/order
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderDto orderDto)
        {   
            await _orderService.Update(orderDto);
            return Ok();
        }


        // PUT api/order
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OrderDto orderDto)
        {   
            await _orderService.Delete(orderDto);
            return Ok();
        } 
    }
}