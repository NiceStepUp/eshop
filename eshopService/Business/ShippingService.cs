using AutoMapper;
using eshop.Common.Service.Business;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using eshop.Persistence.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshopService.Business
{
    public class ShippingService : IShippingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public ShippingService(IUnitOfWork unitOfWork, IShippingRepository shippingRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }


        public async Task Add(ShippingDto shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            await _shippingRepository.Add(shipping);
            await _unitOfWork.Commit();
        }


        public async Task Delete(ShippingDto shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            _shippingRepository.Delete(shipping);
            await _unitOfWork.Commit();
        }


        public async Task<IEnumerable<ShippingDto>> GetAll()
        {
            var shippings = await _shippingRepository.GetAll();
            return _mapper.Map<IEnumerable<ShippingDto>>(shippings);
        }


        public async Task<ShippingDto> GetById(int id)
        {
            return _mapper.Map<ShippingDto>(await _shippingRepository.GetById(id));
        }


        public async Task Update(ShippingDto shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            _shippingRepository.Update(shipping);
            await _unitOfWork.Commit();
        }
    }
}
