using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Services;
using WebApi.Data.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var foods = _foodService.GetAllFoods();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var food = _foodService.GetFoodById(id);
            if (food == null)
                return NotFound();

            return Ok(food);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Food food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _foodService.AddFood(food);
            return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Food food)
        {
            if (id != food.Id)
                return BadRequest("Id mismatch.");

            var existing = _foodService.GetFoodById(id);
            if (existing == null)
                return NotFound();

            _foodService.UpdateFood(food);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _foodService.GetFoodById(id);
            if (existing == null)
                return NotFound();

            _foodService.DeleteFood(id);
            return NoContent();
        }
    }
}
