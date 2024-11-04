package sep3.warehouse.services.stockService;


import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import sep3.warehouse.models.ProductStock;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class StockServiceImplementation {
    private final StockService stockService;


    public int getProductStockById(Long productId) {
        Optional<ProductStock> productStock = stockService.findById(productId);

        return productStock.map(ProductStock::getQuantity).orElseThrow(() -> new IllegalArgumentException("product with id: " + productId + " not found"));
    }
}
