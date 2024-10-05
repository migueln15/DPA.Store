using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategory(Category category);
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> UpdateCategory(Category category);
        Task<Category> GetCategorProductById(int id);
    }
}