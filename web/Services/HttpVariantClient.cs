using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using sep3.DTO.Product;
using Newtonsoft.Json;
using web.Model;

namespace web.Services;

public class HttpVariantClient :  IVariantService
{
    private readonly HttpClient _httpClient;
    
    public HttpVariantClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<List<ProductVariant>?> GetProductVariantsAsync()
    {
        var httpResponse = _httpClient.GetAsync("/variants");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var variants = JsonConvert.DeserializeObject<List<ProductVariant>>(content.Result);
        return Task.FromResult(variants);
    }

    public Task<ProductVariant?> GetProductVariantAsync(int id)
    {
        var httpResponse = _httpClient.GetAsync($"/variants/{id}");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var variant = JsonConvert.DeserializeObject<ProductVariant>(content.Result);
        return Task.FromResult(variant);
    }

    public async Task<ProductVariant> CreateProductVariantsAsync(ProductVariantDTO variant)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/variants", variant);
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new ProductVariant();
    }

    public Task<ProductVariant?> UpdateProductVariantAsync(int id, ProductVariant variant)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductVariantAsync(int id)
    {
        throw new NotImplementedException();
    }
}