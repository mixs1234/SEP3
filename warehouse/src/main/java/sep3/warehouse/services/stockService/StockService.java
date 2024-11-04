package sep3.warehouse.services.stockService;

import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.models.ProductStock;

public interface StockService extends JpaRepository<ProductStock, Long> {}
