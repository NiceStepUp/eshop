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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Add(product);
            await _unitOfWork.Commit();
            productDto.Id = product.Id;
        }

        public async Task Delete(int id)
        {
            _productRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Update(product);
            await _unitOfWork.Commit();
            productDto.Id = product.Id;
        }
    }
}
