using WebApi.Data.Models;
using WebApi.Api.Repositories;
namespace WebApi.Api.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repo;

        public FoodService(IFoodRepository repo) => _repo = repo;

        public List<Food> GetAllFoods()
        {
            return _repo.GetAllAsync()
                .Select(f => new Food
                {
                    Id = f.Id,
                    Name = f.Name,
                    Price = f.Price,
                    Quantity = f.Quantity
                }).ToList();
        }

        public Food GetFoodById(int id)
        {
            var food = _repo.GetByIdAsync(id);

            if (food == null) return null;

            return new Food
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price,
                Quantity = food.Quantity
            };
        }

        public void AddFood(Food f)
        {
            var food = new Food
            {
                Id = f.Id,
                Name = f.Name,
                Price = f.Price,
                Quantity = f.Quantity
            };

            _repo.AddAsync(food);
        }

        public void UpdateFood(Food f)
        {
            var food = new Food
            {
                Id = f.Id,
                Name = f.Name,
                Price = f.Price,
                Quantity = f.Quantity
            };

            _repo.UpdateAsync(food);
        }

        public void DeleteFood(int id)
        {
            _repo.DeleteAsync(id);
        }
    }
}
