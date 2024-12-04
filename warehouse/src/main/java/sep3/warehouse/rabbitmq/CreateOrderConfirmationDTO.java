package sep3.warehouse.rabbitmq;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Map;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class CreateOrderConfirmationDTO {
    private int orderId;
    private Map<Long, Integer> productVariantIdToQuantity;
}
