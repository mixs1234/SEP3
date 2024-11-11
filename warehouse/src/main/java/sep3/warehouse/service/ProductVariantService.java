package sep3.warehouse.service;

import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.service.IProductVariantService;

import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
public class ProductVariantService {
    private final IProductVariantService productVariantService;

    public Optional<ProductVariant> findById(long id) {
        return productVariantService.findById(id);
    }

    public List<ProductVariant> findAllByProductId(long productId) {
        return productVariantService.findAllByProductId(productId);
    }

    public ProductVariant updateQuantity(long variantId, int quantity) {
        ProductVariant productVariant = productVariantService.findById(variantId)
                .orElseThrow(() -> new EntityNotFoundException("ProductVariant with id " + variantId + " not found"));

        int currentStock = productVariant.getStock();
        int newStock = currentStock - quantity;
        productVariant.setStock(newStock);

        productVariantService.save(productVariant);

        return productVariant;
    }
}
