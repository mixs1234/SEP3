package sep3.warehouse.rabbitmq;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class StockVerificationDTO {
    private long orderId;
    private boolean isInStock;
}
