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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderDto> Add(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.Add(order);
            await _unitOfWork.Commit();
            orderDto.Id = order.Id;
            return orderDto;

        }

        public async Task Delete(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.Delete(order);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(await _orderRepository.GetAll());
        }

        public async Task<OrderDto> GetById(int id)
        {
            return _mapper.Map<OrderDto>(await _orderRepository.GetById(id));
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(string id)
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetOrdersByUserId(id));
        }

        public async Task Update(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.Update(order);
            await _unitOfWork.Commit();
        }
    }
}
