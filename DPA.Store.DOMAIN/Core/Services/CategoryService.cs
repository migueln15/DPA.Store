using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();

            var categoriesDTO = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                var categoryDTO = new CategoryDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;
                categoryDTO.IsActive = category.IsActive;
                categoriesDTO.Add(categoryDTO);
            }

            return categoriesDTO;
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            var categoryDTO = new CategoryListDTO();

            categoryDTO.Id = category.Id;
            categoryDTO.Description = category.Description;

            return categoryDTO;
        }

    }
}
