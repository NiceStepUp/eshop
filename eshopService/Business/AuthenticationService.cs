using eshop.Common.Constants;
using eshop.Common.Service.Business;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using eshop.Persistence.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eshopService.Business
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        

        public AuthenticationService(UserManager<Customer> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public async Task<AuthenticationInfo> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return new AuthenticationInfo { IsUserExists = false };

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!isCorrectPassword)
                return new AuthenticationInfo { IsUserExists = false };

            var roles = await _userManager.GetRolesAsync(user);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: Constants.SecurityTokenIssuer,
                audience: Constants.SecurityTokenAudience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials
            );

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return new AuthenticationInfo
            {
                Id = user.Id,
                AuthToken = jwtTokenHandler.WriteToken(tokeOptions),
                /*ExpiresIn = tokeOptions.ValidTo,*/
                Customer = user,
                Roles = roles,
                IsUserExists = true
            };
        }
    }
}
