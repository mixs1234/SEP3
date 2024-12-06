using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web.Model.Order;

namespace web.Services;

public class HttpStatusClient : IStatusService
{
    private readonly HttpClient _httpClient;
    
    public HttpStatusClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public async Task<List<CurrentStatus>?> GetStatusesAsync()
    {
        var httpResponse = _httpClient.GetAsync("/Status");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        
        var statuses = JsonConvert.DeserializeObject<List<CurrentStatus>>(content.Result, settings);
        return statuses;
    }
}