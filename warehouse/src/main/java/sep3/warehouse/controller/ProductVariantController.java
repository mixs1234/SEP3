package sep3.warehouse.controller;


import lombok.Getter;
import lombok.RequiredArgsConstructor;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.service.ProductVariantService;

import java.util.Optional;

@RestController
@RequestMapping("/api/variants")
@RequiredArgsConstructor
public class ProductVariantController {
    private final ProductVariantService productVariantService;

    @GetMapping("/{id}")
    public ResponseEntity<ProductVariant> getProductVariantById(@PathVariable Long id) {

        ProductVariant productVariant = productVariantService.findById(id).orElseThrow(()->new IllegalArgumentException("No product found with id: " +id));
        return ResponseEntity.ok(productVariant);
    }

}
