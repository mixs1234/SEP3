package sep3.warehouse.service;


import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.BrandDTO;
import sep3.warehouse.DTO.ProductDTO;
import sep3.warehouse.entities.Brand;
import sep3.warehouse.entities.Product;

import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
public class ProductService {
    private final IProductService productService;
    private final IBrandService brandService;

    public ProductDTO findById(Long id) {
        Product product = productService.findById(id).orElseThrow(()-> new EntityNotFoundException("product with " + id +  "not found"));

        return ProductDTO.ProductMapToDTONoVariants(product);
    }

    public List<ProductDTO> findAll() {
        List<Product> products = productService.findAll();

        return products.stream().map(ProductDTO::ProductMapToDTONoVariants).toList();
    }

    public Optional<Product> createProduct (ProductDTO productDTO ) {
        Product product = new Product();
        Optional<Brand> brand = brandService.findById(productDTO.getBrand().getId());

        if (brand.isPresent()) {
            product.setName(productDTO.getName());
            product.setDescription(productDTO.getDescription());
            product.setBrand(brand.get());
        }
        return Optional.of(productService.save(product));
    }
}
