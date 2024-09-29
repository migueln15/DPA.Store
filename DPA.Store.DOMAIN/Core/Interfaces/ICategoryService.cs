using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
    }
}