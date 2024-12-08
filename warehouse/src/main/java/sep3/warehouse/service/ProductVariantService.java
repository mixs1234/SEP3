package sep3.warehouse.service;

import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.productVariants.CreateProductVariantDto;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.DTO.productVariants.UpdateProductVariantDto;
import sep3.warehouse.entities.ArchiveStatus;
import sep3.warehouse.entities.ProductVariant;

import java.util.List;

@Service
@RequiredArgsConstructor
public class ProductVariantService {
    private final ProductVariantRepo productVariantService;
    private final ProductRepo productService;
    protected final ArchiveStatusService archiveStatus;
    private final ArchiveStatusService archiveStatusService;
    private final ArchiveStatusHistoryService archiveStatusHistoryService;

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
        productVariant.setArchiveStatus(archiveStatus.getArchiveStatusById(2));
        productVariantService.save(productVariant);

        return ProductVariantDTO.mapFromProductVariantToDTO(productVariant);
    }

    public ProductVariantDTO updateProductVariant(UpdateProductVariantDto updateProductVariantDto){
        if(updateProductVariantDto == null){
            throw  new IllegalArgumentException("productVariantDTO");
        }

        ProductVariant productVariant = productVariantService.findById(updateProductVariantDto.getId()).orElseThrow(() ->
                new IllegalArgumentException("Id not in DB"));

        productVariant.setMaterial(updateProductVariantDto.getMaterial());
        productVariant.setSize(updateProductVariantDto.getSize());
        productVariant.setStock(updateProductVariantDto.getStock());
        productVariant.setArchiveStatus(archiveStatus.getArchiveStatusById(updateProductVariantDto.getArchiveStatusId()));
        productVariantService.save(productVariant);

        return ProductVariantDTO.mapFromProductVariantToDTO(productVariant);
    }

    public ProductVariantDTO updateVariantArchiveStatusById(long productVariantId, long archiveStatusId) {
        ProductVariant variant = productVariantService.findById(productVariantId)
                .orElseThrow(() -> new EntityNotFoundException("Product variant not found with ID: " + productVariantId));

        ArchiveStatus archiveStatus = archiveStatusService.getArchiveStatusById(archiveStatusId);

        variant.setArchiveStatus(archiveStatus);

        archiveStatusHistoryService.createArchiveStatusHistory(archiveStatus, variant);
        productVariantService.save(variant);
        return ProductVariantDTO.mapFromProductVariantToDTO(variant);
    }
}
