package sep3.warehouse.DTO.products;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.DTO.brands.BrandDTO;
import sep3.warehouse.entities.Product;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CreateProductDto {
    private String name;
    private String description;
    private double price;
    private String imagePath;
    private BrandDTO brand;

    public static Product mapCreateProductDtoToProduct(CreateProductDto createProductDto) {
        Product product = new Product();
        product.setName(createProductDto.getName());
        product.setDescription(createProductDto.getDescription());
        product.setPrice(createProductDto.getPrice());
        product.setImagePath(createProductDto.getImagePath());
        product.setBrand(BrandDTO.mapBrandDtoToBrand(createProductDto.getBrand()));

        return product;
    }
}
