using WebApi.Data.Models;

namespace WebApi.Api.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodieAppDbContext _context;

        public FoodRepository(FoodieAppDbContext context)
        {
            _context = context;
        }
        public void AddAsync(Food food)
        {
            _context.Add(food);
            _context.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
            Food food = _context.Foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                _context.Remove(food);
                _context.SaveChanges();
            }
        }

        public List<Food> GetAllAsync()
        {
            return _context.Foods.ToList();
        }

        public Food GetByIdAsync(int id)
        {
            return _context.Foods.FirstOrDefault(food => food.Id == id);
        }

        public void UpdateAsync(Food food)
        {
            _context.Update(food);
            _context.SaveChanges();
        }
    }
}
