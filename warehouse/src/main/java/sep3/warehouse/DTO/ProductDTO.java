package sep3.warehouse.DTO;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.entities.Product;
import sep3.warehouse.entities.ProductVariant;

import java.util.ArrayList;
import java.util.List;



@NoArgsConstructor
@AllArgsConstructor
@Data
public class ProductDTO {
    private Long id;
    private String name;
    private String description;
    private double price;
    private String imagePath;
    private BrandDTO brand;
    private List<ProductVariant> productVariants;


    public static ProductDTO ProductMapToDTO(Product product) {
        ProductDTO productDTO = new ProductDTO();
        productDTO.setId(product.getId());
        productDTO.setName(product.getName());
        productDTO.setDescription(product.getDescription());
        productDTO.setPrice(product.getPrice());
        productDTO.setImagePath(product.getImagePath());
        productDTO.setBrand(BrandDTO.MapBrandToBrandDTO(product.getBrand()));
        productDTO.setProductVariants(product.getProductVariants());

        return productDTO;
    }

    public static ProductDTO ProductMapToDTONoVariants(Product product) {
        ProductDTO productDTO = new ProductDTO();
        productDTO.setId(product.getId());
        productDTO.setName(product.getName());
        productDTO.setDescription(product.getDescription());
        productDTO.setPrice(product.getPrice());
        productDTO.setImagePath(product.getImagePath());
        productDTO.setBrand(BrandDTO.MapBrandToBrandDTO(product.getBrand()));
        productDTO.setProductVariants(new ArrayList<>());
        return productDTO;
    }



}