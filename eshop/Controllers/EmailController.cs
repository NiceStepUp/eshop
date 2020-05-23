using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Common.Service.Core;
using eshop.Persistence.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;


        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpGet]
        public async Task<IActionResult> SendEmail(string emailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (emailAddress != null)
            {   
                var message = new MessageDto(new string[] { emailAddress }, "Test email", "This is the content from our email.");
                await _emailService.SendEmailAsync(message);
                return Ok();
            }

            return BadRequest();
        }
    }
}