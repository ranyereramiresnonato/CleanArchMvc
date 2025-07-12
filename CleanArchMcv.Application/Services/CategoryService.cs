using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task AddAsync(CategoryDTO categoryDTO)
        {
            var categoryEtity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categoryEtity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categoriesEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
