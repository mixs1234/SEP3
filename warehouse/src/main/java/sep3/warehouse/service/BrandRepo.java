package sep3.warehouse.service;



import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.Brand;


public interface BrandRepo extends JpaRepository<Brand, Long> { }
