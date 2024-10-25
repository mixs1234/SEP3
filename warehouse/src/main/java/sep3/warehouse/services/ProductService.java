package sep3.warehouse.services;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import sep3.warehouse.models.Product;

public interface ProductService extends JpaRepository<Product, Long> {
}
