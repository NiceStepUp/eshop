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
    public  class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IMapper _mapper;

        public ShoppingCartItemService(IUnitOfWork unitOfWork, IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _mapper = mapper;
        }


        public async Task<ShoppingCartItemDto> Add(ShoppingCartItemDto shoppingCartItemDto)
        {
            var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);
            await _shoppingCartItemRepository.Add(shoppingCartItem);
            await _unitOfWork.Commit();
            shoppingCartItemDto.Id = shoppingCartItem.Id;
            return shoppingCartItemDto;
        }

        public async Task Delete(ShoppingCartItemDto shoppingCartItemDto)
        {
            var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);
            _shoppingCartItemRepository.Delete(shoppingCartItem);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<ShoppingCartItemDto>> GetAll()
        {
            var shoppingCartItems = await _shoppingCartItemRepository.GetAll();
            return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shoppingCartItems);
        }

        public async Task<ShoppingCartItemDto> GetByIdAndProductId(Guid id, int productId)
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetByIdAndProductId(id, productId);
            return _mapper.Map<ShoppingCartItemDto>(shoppingCartItem);
        }

        public async Task<ShoppingCartItemDto> Update(ShoppingCartItemDto shoppingCartItemDto)
        {
            var product = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);
            _shoppingCartItemRepository.Update(product);
            await _unitOfWork.Commit();
            shoppingCartItemDto.Id = product.Id;
            return shoppingCartItemDto;
        }
    }
}
