using BonApp.Infrastructure.Data.DTOs;
using Newtonsoft.Json;

namespace BonApp.WebUI.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ProductListDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5238/api/Product"); // URL của API
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ProductListDto>>(content);
    }
}
