using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task<int> Insert(CategoryDescriptioDTO categoryDescriptioDTO);
        Task<bool> Update(CategoryListDTO categoryDTO);
        Task<CategoryProductsDTO> GetCategoryProductsById(int id);
    }
}