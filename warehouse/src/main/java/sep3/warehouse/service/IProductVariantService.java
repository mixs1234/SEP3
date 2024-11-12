package sep3.warehouse.service;


import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.ProductVariant;

import java.util.List;

public interface IProductVariantService extends JpaRepository<ProductVariant, Long> {
    List<ProductVariant> findAllByProductId(long productId);
}
