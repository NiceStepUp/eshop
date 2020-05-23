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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Add(category);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            _categoryRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Update(category);
            await _unitOfWork.Commit();
        }
    }
}
