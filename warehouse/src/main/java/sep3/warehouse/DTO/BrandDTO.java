package sep3.warehouse.DTO;


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

    public static BrandDTO MapBrandToBrandDTO(Brand brand) {
        BrandDTO brandDTO = new BrandDTO();

        brandDTO.setId(brand.getId());
        brandDTO.setName(brand.getName());
        return brandDTO;
    }
}
