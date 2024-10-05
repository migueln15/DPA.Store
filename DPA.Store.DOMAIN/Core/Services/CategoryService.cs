using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Services
{
    public class CategoryService : ICategoryService
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

        public async Task<int> Insert(CategoryDescriptioDTO categoryDescriptioDTO)
        {
            var category = new Category();
            category.Description = categoryDescriptioDTO.Description;
            category.IsActive = true;

            int id = await _categoryRepository.CreateCategory(category);

            return id;
        }

        public async Task<bool> Update(CategoryListDTO categoryDTO)
        {
            var category = new Category();
            category.Id = categoryDTO.Id;
            category.Description = categoryDTO.Description;

            return await _categoryRepository.UpdateCategory(category);

        }

        public async Task<bool> Delete(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }

        public async Task<CategoryProductsDTO> GetCategoryProductsById(int id)
        {
            var category = await _categoryRepository.GetCategorProductById(id);

            var categoryProductsDTO = new CategoryProductsDTO();
            categoryProductsDTO.Id = category.Id;
            categoryProductsDTO.Description = category.Description;

            var products = new List<ProductListDTO>();
            foreach(var cp in category.Product)
            {
                var product = new ProductListDTO();
                product.Id = cp.Id;
                product.Description = cp.Description;
                products.Add(product);
            }

            categoryProductsDTO.Products = products;
            return categoryProductsDTO;
        }

    }
}
