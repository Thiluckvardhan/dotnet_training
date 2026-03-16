using WebApi.Data.Models;

namespace WebApi.Api.Repositories
{
    public interface IFoodRepository
    {
        List<Food> GetAllAsync();
        Food GetByIdAsync(int id);
        void AddAsync(Food food);
        void UpdateAsync(Food food);
        void DeleteAsync(int id);
    }
}
