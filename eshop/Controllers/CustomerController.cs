
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eshop.Common.Service.Business;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private IOptions<AppSettingsModel> _settings;

        public CustomerController(ICustomerService customerService, IMapper mapper, IOptions<AppSettingsModel> settings)
        {
            _customerService = customerService;
            _mapper = mapper;
            _settings = settings;
        }

        // GET api/customer
        [HttpGet]
        public async Task<CustomerDto> Get(string id, bool showAllInfo)
        {
            return _mapper.Map<CustomerDto>(await _customerService.GetById(id, showAllInfo));
        }

        // GET api/getall
        [HttpGet("GetAll"), Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(await _customerService.GetAll()));
        }

        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {   
            await _customerService.Add(customerDto, customerDto.Password);
            return Ok(customerDto);
        }


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] CustomerDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(forgotPasswordDto);

            return Ok(await _customerService.ForgotPassword(forgotPasswordDto, _settings.Value.ResetCallbackUrl));
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] CustomerDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(forgotPasswordDto);

            return Ok(await _customerService.ResetPassword(forgotPasswordDto));
        }


        // PUT api/customer
        [HttpPut, Authorize]
        public async Task<IActionResult> Put([FromBody] CustomerDto customerDto)
        {
            await _customerService.Update(customerDto);
            return Ok(customerDto);
        }


        // PUT api/customer
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete([FromBody] CustomerDto customerDto)
        {   
            await _customerService.Delete(customerDto);
            return Ok();
        }
    }
}