package sep3.warehouse.service;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import sep3.warehouse.entities.Product;

import java.util.List;

public interface IProductService extends JpaRepository<Product, Long> {
    public List<Product> findByBrand_Id(Long brandId);
}
