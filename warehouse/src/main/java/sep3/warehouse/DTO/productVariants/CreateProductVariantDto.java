package sep3.warehouse.DTO.productVariants;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.DTO.products.ProductDTO;
import sep3.warehouse.entities.ProductVariant;
@Data
@AllArgsConstructor
@NoArgsConstructor
public class CreateProductVariantDto {
    private String size;
    private String material;
    private int stock;
    private long productId;

    public static ProductVariant mapCreateProductVariantDtotoProductVariant(CreateProductVariantDto createProductVariantDto) {
        ProductVariant productVariant = new ProductVariant();
        productVariant.setSize(createProductVariantDto.getSize());
        productVariant.setMaterial(createProductVariantDto.getMaterial());
        productVariant.setStock(createProductVariantDto.getStock());
        productVariant.setProduct(null);
        return productVariant;
    }
}
