using AutoMapper;
using eshop.Common.Service.Business;
using eshop.Common.Service.Core;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using eshop.Persistence.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshopService.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<Customer> _userManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;


        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, UserManager<Customer> userManager, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
        }


        public async Task Add(CustomerDto customerDto, string password)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.Add(customer, password);
            await _unitOfWork.Commit();
        }


        public async Task Delete(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Delete(customer);
            await _unitOfWork.Commit();
        }


        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await _customerRepository.GetAll();            
            return _mapper.Map<IEnumerable<CustomerDto>>(customers); ;
        }


        public async Task<CustomerDto> GetById(string id, bool showAllInfo)
        {
            var customer = await _customerRepository.GetById(id);
            var userRoles = await _userManager.GetRolesAsync(customer);
            return new CustomerDto
            {
                Id = customer.Id,
                UserName = customer.UserName,
                IsAdmin = userRoles.Count > 0 ?  userRoles.Contains("Admin") : false,
                FirstName = showAllInfo ? customer.FirstName : string.Empty,
                LastName = showAllInfo ? customer.LastName : string.Empty
            };
        }


        public async Task Update(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.Update(customer);
            await _unitOfWork.Commit();
        }


        public async Task<CustomerDto> ForgotPassword(CustomerDto customerDto, string resetCallbackUrl)
        {
            var user = await _userManager.FindByEmailAsync(customerDto.Email);
            if (user == null)
                return new CustomerDto();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = $"{resetCallbackUrl}?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(customerDto.Email)}";
            await _emailService.SendEmailAsync(new MessageDto(new string[] { customerDto.Email }, "Reset password token", callback));
            return customerDto;
        }


        public async Task<CustomerDto> ResetPassword(CustomerDto customerDto)
        {
            var user = await _userManager.FindByEmailAsync(customerDto.Email);
            if (user == null)
                return new CustomerDto();

            var resetPassResult = await _userManager.ResetPasswordAsync(user, customerDto.EmailToken, customerDto.ConfirmPassword);
            if (!resetPassResult.Succeeded)
            {
                var error = resetPassResult.Errors.FirstOrDefault();
                if (error != null)
                    throw new Exception(error.Description);
            }
            return customerDto;
        }
    }
}
