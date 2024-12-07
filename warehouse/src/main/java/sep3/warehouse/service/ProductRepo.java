package sep3.warehouse.service;

import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.Product;

import java.util.List;

public interface ProductRepo extends JpaRepository<Product, Long> {
    public List<Product> findByBrand_Id(Long brandId);
}
