using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;
using Newtonsoft.Json;
using web.Model;

namespace web.Services;

public class HttpVariantClient : IVariantService
{
    private readonly HttpClient _httpClient;

    public HttpVariantClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductVariant>?> GetProductVariantsAsync()
    {
        var httpResponse = await _httpClient.GetAsync("/ProductVariant");
        var content = await httpResponse.Content.ReadAsStringAsync();
        var variants = JsonConvert.DeserializeObject<List<ProductVariant>>(content);
        return variants;
    }

    public async Task<ProductVariant> CreateProductVariantAsync(CreateProductVariantDTO variant)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/ProductVariant", variant);
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new ProductVariant();
    }

    public Task<ProductVariant?> UpdateProductVariantAsync(int id, ProductVariantDTO variant)
    {
        var httpResponse = _httpClient.PutAsJsonAsync($"/ProductVariant/{id}", variant);
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        
        if (!httpResponse.Result.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to update variant with ID {id}: {httpResponse.Result.ReasonPhrase}");
        }
        
        var updatedVariant = JsonConvert.DeserializeObject<ProductVariant>(content.Result);
        return Task.FromResult(updatedVariant);
    }

}