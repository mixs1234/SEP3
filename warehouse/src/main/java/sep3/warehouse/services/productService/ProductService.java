package sep3.warehouse.services.productService;

import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.models.Product;

public interface ProductService extends JpaRepository<Product, Long> {
}
