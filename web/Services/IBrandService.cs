using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.DTO.Product;

namespace web.Services;

public interface IBrandService
{
    Task<List<BrandDTO>?> GetBrandsAsync();
    Task<BrandDTO?> GetBrandAsync(int id);
}