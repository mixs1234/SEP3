package sep3.warehouse.DTO.products;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.DTO.brands.BrandDTO;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
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
    private List<ProductVariantDTO> productVariants;


    public static ProductDTO mapProductToProductDTO(Product product) {
        ProductDTO productDTO = new ProductDTO();
        productDTO.setId(product.getId());
        productDTO.setName(product.getName());
        productDTO.setDescription(product.getDescription());
        productDTO.setPrice(product.getPrice());
        productDTO.setImagePath(product.getImagePath());
        productDTO.setBrand(BrandDTO.mapBrandToBrandDTO(product.getBrand()));
        productDTO.setProductVariants(product.getProductVariants().stream().map(ProductVariantDTO::mapFromProductVariantToDTO).toList());

        return productDTO;
    }

    public static ProductDTO mapProductToDTONoVariants(Product product) {
        ProductDTO productDTO = new ProductDTO();
        productDTO.setId(product.getId());
        productDTO.setName(product.getName());
        productDTO.setDescription(product.getDescription());
        productDTO.setPrice(product.getPrice());
        productDTO.setImagePath(product.getImagePath());
        productDTO.setBrand(BrandDTO.mapBrandToBrandDTO(product.getBrand()));
        productDTO.setProductVariants(new ArrayList<>());
        return productDTO;
    }

    public static Product mapProductDTOToProduct(ProductDTO productDTO) {
        Product product = new Product();
        product.setId(productDTO.getId());
        product.setName(productDTO.getName());
        product.setDescription(productDTO.getDescription());
        product.setPrice(productDTO.getPrice());
        product.setImagePath(productDTO.getImagePath());
        product.setBrand(BrandDTO.mapBrandDtoToBrand(productDTO.getBrand()));
        product.setProductVariants(productDTO.getProductVariants().stream().map(ProductVariantDTO::mapFromDTOToProductVariant).toList());
        return product;
    }
    public static Product mapProductDTOToProductNoVariants(ProductDTO productDTO) {
        Product product = new Product();
        product.setId(productDTO.getId());
        product.setName(productDTO.getName());
        product.setDescription(productDTO.getDescription());
        product.setPrice(productDTO.getPrice());
        product.setImagePath(productDTO.getImagePath());
        product.setBrand(BrandDTO.mapBrandDtoToBrand(productDTO.getBrand()));
        product.setProductVariants(new ArrayList<>());
        return product;
    }


}