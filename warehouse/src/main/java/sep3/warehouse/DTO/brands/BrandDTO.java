package sep3.warehouse.DTO.brands;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.entities.Brand;

@NoArgsConstructor
@AllArgsConstructor
@Data
public class BrandDTO {
    private String name;
    private Long id;

    public static BrandDTO mapBrandToBrandDTO(Brand brand) {
        BrandDTO brandDTO = new BrandDTO();

        brandDTO.setId(brand.getId());
        brandDTO.setName(brand.getName());
        return brandDTO;
    }

    public static Brand mapBrandDtoToBrand(BrandDTO brandDTO) {
        Brand brand = new Brand();
        brand.setId(brandDTO.getId());
        brand.setName(brandDTO.getName());

        return brand;
    }
}
