package sep3.warehouse.service;

import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.productVariants.CreateProductVariantDto;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.service.IProductVariantService;

import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
public class ProductVariantService {
    private final IProductVariantService productVariantService;
    private final IProductService productService;

    public ProductVariantDTO findById(long id) {

         ProductVariant productVariant = productVariantService.findById(id).orElseThrow(()-> new EntityNotFoundException("Product variant with id: " + id + " not found"));

         return ProductVariantDTO.mapFromProductVariantToDTO(productVariant);
    }

    public List<ProductVariantDTO> findAllByProductId(long productId) {
        return productVariantService.findAllByProductId(productId).stream().map(ProductVariantDTO::mapFromProductVariantToDTO).toList();
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

    public ProductVariantDTO createProductVariant(CreateProductVariantDto createProductVariantDto) {
        if (createProductVariantDto == null){
            throw new IllegalArgumentException("createProductVariantDto is null");
        }

        if (!productService.existsById(createProductVariantDto.getProductId())){
            throw new IllegalArgumentException("Cannot create variant without main product, no product with id: "
                    + createProductVariantDto.getProductId() + " was found");
        }

        ProductVariant productVariant = CreateProductVariantDto.mapCreateProductVariantDtotoProductVariant(createProductVariantDto);
        productVariant.setProduct(productService.findById(createProductVariantDto.getProductId()).orElseThrow());
        productVariantService.save(productVariant);

        return ProductVariantDTO.mapFromProductVariantToDTO(productVariant);
    }

    public ProductVariantDTO updateProductVariant(ProductVariantDTO productVariantDTO){
        if(productVariantDTO == null){
            throw  new IllegalArgumentException("productVariantDTO");
        }

        ProductVariant productVariant = productVariantService.findById(productVariantDTO.getId()).orElseThrow(() ->
                new IllegalArgumentException("Id not in DB"));

        productVariant.setMaterial(productVariantDTO.getMaterial());
        productVariant.setSize(productVariantDTO.getSize());
        productVariant.setStock(productVariantDTO.getStock());

        productVariantService.save(productVariant);

        return ProductVariantDTO.mapFromProductVariantToDTO(productVariant);
    }

    public void removeVariantById(long productVariantId) {
        ProductVariant variant = productVariantService.findById(productVariantId)
                .orElseThrow(() -> new EntityNotFoundException("Product variant not found with ID: " + productVariantId));

        productVariantService.delete(variant);
    }
}
