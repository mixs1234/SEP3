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
        var httpResponse = _httpClient.GetAsync($"/Product/{id}");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content.Result);
        return Task.FromResult(product);
    }
    

    // Admin only
    public async Task<Product> CreateProductAsync(ProductDTO productDto)
    {
        
        
        var httpResponse = await _httpClient.PostAsJsonAsync("/Product", productDto);
        var response = await httpResponse.Content.ReadAsStringAsync();
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to create product: {httpResponse.ReasonPhrase}");
        }
        
        Console.WriteLine("Product created");
        return new Product();
    }

    // Admin only
    public Task<Product?> UpdateProductAsync(int id, Product product)
    {
        throw new System.NotImplementedException();
    }

    // Admin only
    public async Task DeleteProductAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"Product/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }
}