using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using sep3.DTO.Product;

namespace web.Services;

public class HttpBrandClient : IBrandService
{
    private readonly HttpClient _httpClient;
    private readonly System.Text.Json.JsonSerializerOptions _options;

    public HttpBrandClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<BrandDTO>?> GetBrandsAsync()
    {
        var httpResponse = await _httpClient.GetAsync("/Brand");
        var content = await httpResponse.Content.ReadAsStringAsync();
        var brands = System.Text.Json.JsonSerializer.Deserialize<List<BrandDTO>>(content, _options);
        return brands;
    }

    public Task<BrandDTO?> GetBrandAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}