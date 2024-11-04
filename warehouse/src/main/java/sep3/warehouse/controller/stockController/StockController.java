package sep3.warehouse.controller.stockController;


import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import sep3.warehouse.services.stockService.StockService;
import sep3.warehouse.services.stockService.StockServiceImplementation;

@RestController
@RequestMapping("/api/stocks")
@RequiredArgsConstructor
public class StockController {

    private final StockServiceImplementation stockServiceImplementation;

    @GetMapping("/{productId}")
    public ResponseEntity<Integer> getProductStockById(@PathVariable Long productId){
        int quantity = stockServiceImplementation.getProductStockById(productId);

        return ResponseEntity.ok(quantity);
    }



}
