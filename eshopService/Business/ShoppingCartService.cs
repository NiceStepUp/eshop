using AutoMapper;
using eshop.Common.Service.Business;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using eshop.Persistence.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshopService.Business
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartService(IUnitOfWork unitOfWork, IShoppingCartRepository shoppingCartRepository, IShoppingCartItemRepository shoppingCartItemRepository,
            IProductRepository productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ShoppingCartDto> Add(ShoppingCartDto shoppingCartDto)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);
            await _shoppingCartRepository.Add(shoppingCart);
            await _unitOfWork.Commit();
            shoppingCartDto.Id = shoppingCart.Id;
            return shoppingCartDto;
        }


        public async Task Delete(ShoppingCartDto shoppingCartDto)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);
            _shoppingCartRepository.Delete(shoppingCart);

            await _unitOfWork.Commit();
        }


        public async Task<IEnumerable<ShoppingCartDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShoppingCartDto>>(await _shoppingCartRepository.GetAll());
        }


        public async Task<ShoppingCartDto> GetById(Guid id)
        {
            return _mapper.Map<ShoppingCartDto>(await _shoppingCartRepository.GetById(id));
        }

        public async Task<ShoppingCartDto> Update(ShoppingCartDto shoppingCartDto)
        {
            var productId = shoppingCartDto.ShoppingCartItems.FirstOrDefault().Product.Id;
            var shoppingCartItem = await _shoppingCartItemRepository.GetByIdAndProductId(shoppingCartDto.Id, productId);

            if (shoppingCartItem == null)
            {
                var product = await _productRepository.GetById(productId);
                var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartDto.Id);
                shoppingCartItem = new ShoppingCartItem() { Product = product, ShoppingCart = shoppingCart, Quantity = 1 };
                await _shoppingCartItemRepository.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity += shoppingCartDto.ShoppingCartItems.FirstOrDefault().Quantity;
                _shoppingCartItemRepository.Update(shoppingCartItem);
            }

            await _unitOfWork.Commit();
            shoppingCartDto = await GetById(shoppingCartDto.Id);
            return shoppingCartDto;
        }
    }
}
