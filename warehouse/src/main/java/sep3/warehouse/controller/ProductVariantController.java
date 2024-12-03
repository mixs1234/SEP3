package sep3.warehouse.controller;


import lombok.Getter;
import lombok.RequiredArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import sep3.warehouse.DTO.productVariants.CreateProductVariantDto;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.service.ProductVariantService;

import java.util.Optional;

@RestController
@RequestMapping("/api/variants")
@RequiredArgsConstructor
public class ProductVariantController {
    private final ProductVariantService productVariantService;

    @GetMapping("/{id}")
    public ResponseEntity<ProductVariantDTO> getProductVariantById(@PathVariable Long id) {
        return ResponseEntity.ok(productVariantService.findById(id));
    }

    @PostMapping
    public ResponseEntity<ProductVariantDTO> createProductVariant(@RequestBody CreateProductVariantDto createProductVariantDto) {
        return new ResponseEntity <>(productVariantService.createProductVariant(createProductVariantDto), HttpStatus.CREATED);
    }

    @PutMapping
    public ResponseEntity<ProductVariantDTO> updateProductVariant(@RequestBody ProductVariantDTO productVariantDTO){
        return ResponseEntity.ok(productVariantService.updateProductVariant(productVariantDTO));
    }

}
