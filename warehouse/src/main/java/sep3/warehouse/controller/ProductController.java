package sep3.warehouse.controller;

import lombok.RequiredArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.DTO.products.CreateProductDto;
import sep3.warehouse.DTO.products.ProductDTO;
import sep3.warehouse.entities.Product;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.service.ProductService;
import sep3.warehouse.service.ProductVariantService;

import java.util.List;
import java.util.Optional;


@RestController
@RequiredArgsConstructor
@RequestMapping("/api/products")
public class ProductController {
    private final ProductService productService;
    private final ProductVariantService productVariantService;


    @PostMapping
    public ResponseEntity<ProductDTO> createProduct(@RequestBody CreateProductDto createProductDto) {
        return new ResponseEntity <>(productService.createProduct(createProductDto), HttpStatus.CREATED);
    }

    @GetMapping("/{id}")
    public ResponseEntity<ProductDTO> getProduct(@PathVariable Long id) {
        ProductDTO productDTO = productService.findById(id);

        return ResponseEntity.ok(productDTO);
    }

    @GetMapping("/{id}/variants")
    public ResponseEntity<List<ProductVariantDTO>> getProductWithVariants(@PathVariable Long id) {
        return ResponseEntity.ok(productVariantService.findAllByProductId(id));
    }

    @GetMapping
    public ResponseEntity<List<ProductDTO>> getAllProducts() {
        return ResponseEntity.ok(productService.findAll());
    }
}
