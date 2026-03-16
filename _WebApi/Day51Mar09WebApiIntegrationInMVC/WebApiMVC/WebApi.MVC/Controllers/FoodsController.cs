using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.MVC.Services;

namespace WebApi.MVC.Controllers
{
    public class FoodsController : Controller
    {
        private readonly FoodApiService _foodApiService;

        public FoodsController(FoodApiService foodApiService)
        {
            _foodApiService = foodApiService;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var foods = await _foodApiService.GetAllAsync();
            return View(foods);
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _foodApiService.GetByIdAsync(id.Value);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity")] Food food)
        {
            if (ModelState.IsValid)
            {
                await _foodApiService.CreateAsync(food);
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _foodApiService.GetByIdAsync(id.Value);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _foodApiService.UpdateAsync(id, food);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _foodApiService.GetByIdAsync(id.Value);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _foodApiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
