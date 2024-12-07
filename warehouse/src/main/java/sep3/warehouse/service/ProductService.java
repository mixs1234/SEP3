package sep3.warehouse.service;


import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.products.CreateProductDto;
import sep3.warehouse.DTO.products.ProductDTO;
import sep3.warehouse.entities.Product;

import java.util.List;

@Service
@RequiredArgsConstructor
public class ProductService {
    private final ProductRepo productService;
    private final BrandRepo brandService;

    public ProductDTO findById(Long id) {
        Product product = productService.findById(id).orElseThrow(()-> new EntityNotFoundException("product with " + id +  "not found"));

        return ProductDTO.mapProductToDTONoVariants(product);
    }

    public List<ProductDTO> findAll() {
        List<Product> products = productService.findAll();
        return products.stream().map(ProductDTO::mapProductToDTONoVariants).toList();
    }

    public ProductDTO createProduct (CreateProductDto createProductDto) {
        if (createProductDto == null){
            throw new IllegalArgumentException("createProductDto cannot be null");
        }

        Product product = CreateProductDto.mapCreateProductDtoToProduct(createProductDto);

        productService.save(product);

        return ProductDTO.mapProductToDTONoVariants(product);
    }
}
