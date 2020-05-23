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
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        // GET api/shipping
        [HttpGet]
        public async Task<ShippingDto> Get(int id)
        {
            return await _shippingService.GetById(id);
        }

        // GET api/getall
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shippingService.GetAll());
        }

        // POST api/shipping
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShippingDto shippingDto)
        {
            await _shippingService.Add(shippingDto);
            return Ok();
        }


        // PUT api/shipping
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShippingDto shippingDto)
        {
            await _shippingService.Update(shippingDto);
            return Ok();
        }


        // PUT api/shipping
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ShippingDto shippingDto)
        {
            await _shippingService.Delete(shippingDto);
            return Ok();
        }
    }
}