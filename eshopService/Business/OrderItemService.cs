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
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }


        public async Task<OrderItemDto> Add(OrderItemDto orderItemDto)
        {
            var order = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.Add(order);
            await _unitOfWork.Commit();
            orderItemDto.Id = order.Id;
            return orderItemDto;

        }

        public async Task Delete(OrderItemDto orderItemDto)
        {
            var order = _mapper.Map<OrderItem>(orderItemDto);
            _orderItemRepository.Delete(order);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<OrderItemDto>> GetAll()
        {
            return _mapper.Map<List<OrderItemDto>>(await _orderItemRepository.GetAll());
        }

        public async Task<OrderItemDto> GetById(int id)
        {
            return _mapper.Map<OrderItemDto>(await _orderItemRepository.GetById(id));
        }


        public async Task Update(OrderItemDto orderItemDto)
        {
            var order = _mapper.Map<OrderItem>(orderItemDto);
            _orderItemRepository.Update(order);
            await _unitOfWork.Commit();
        }
    }
}
