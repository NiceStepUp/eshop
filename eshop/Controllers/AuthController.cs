using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eshop.Common.Constants;
using eshop.Common.Service.Business;
using eshop.Infrastructure.Helpers;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {   
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CustomerDto credentialsDto)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);

            var authInfoDto = _mapper.Map<AuthenticationInfoDto>(await _authenticationService.Login(credentialsDto.UserName, credentialsDto.Password));
            return Ok(authInfoDto);
        }
    }
}