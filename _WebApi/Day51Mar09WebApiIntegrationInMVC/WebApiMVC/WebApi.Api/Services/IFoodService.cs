using WebApi.Data.Models;
namespace WebApi.Api.Services
{
    public interface IFoodService
    {
        List<Food> GetAllFoods();
        Food GetFoodById(int id);
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int id);

    }
}
