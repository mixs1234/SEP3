package sep3.warehouse.DTO;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.entities.ProductVariant;

@NoArgsConstructor
@AllArgsConstructor
@Data
public class ProductVariantDTO {
    private Long id;
    private String size;
    private String material;
    private int stock;




    public static ProductVariantDTO mapFromProductVariantToDTO(ProductVariant productVariant) {
        ProductVariantDTO productVariantDTO = new ProductVariantDTO();
        productVariantDTO.setId(productVariant.getId());
        productVariantDTO.setSize(productVariant.getSize());
        productVariantDTO.setMaterial(productVariant.getMaterial());
        productVariantDTO.setStock(productVariant.getStock());
        return productVariantDTO;
    }
}
