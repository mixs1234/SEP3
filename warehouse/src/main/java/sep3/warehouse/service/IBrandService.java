package sep3.warehouse.service;



import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.Brand;

import java.util.List;


public interface IBrandService extends JpaRepository<Brand, Long> { }
