using sep3.broker.Services;
using sep3.DTO.Product;

namespace sep3.brokers.broker;

public interface IBrandBroker
{
    Task<Result<BrandDTO>> GetBrandAsync(int id);
    Task<Result<List<BrandDTO>>> GetAllBrandsAsync();
}