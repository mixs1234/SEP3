using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO.Product;
using Model;
using Newtonsoft.Json;

namespace web.Services;

public class HttpProductClient :  IProductService
{
    private readonly HttpClient _httpClient;
    
    public HttpProductClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<List<Product>?> GetProductsAsync()
    {
        var httpResponse = _httpClient.GetAsync("/product");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<Product>>(content.Result);
        return Task.FromResult(products);
    }

    public Task<Product?> GetProductAsync(int id)
    {
        throw new System.NotImplementedException();
    }
    

    public async Task<Product> CreateProductAsync(ProductDTO productDto)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/Product", productDto);
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new Product();
    }

    public Task<Product?> UpdateProductAsync(int id, Product product)
    {
        throw new System.NotImplementedException();
    }

    public async Task DeleteProductAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"/product/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }
}