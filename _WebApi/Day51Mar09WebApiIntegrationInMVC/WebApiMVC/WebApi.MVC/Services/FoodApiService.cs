using WebApi.Data.Models;

namespace WebApi.MVC.Services
{
    public class FoodApiService
    {
        private readonly HttpClient _httpClient;

        public FoodApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Food>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/Food");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Food>>() ?? [];
        }

        public async Task<Food?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Food/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Food>();
        }

        public async Task<bool> CreateAsync(Food food)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Food", food);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, Food food)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Food/{id}", food);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Food/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
