package sep3.warehouse.rabbitmq.service;


import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.rabbitmq.OrderDTO;
import sep3.warehouse.rabbitmq.StockVerificationDTO;
import sep3.warehouse.service.ProductVariantService;

@Service
@RequiredArgsConstructor
public class OrderListenerService {

    private final StockPublisherService stockPublisherService;
    private final ProductVariantService productVariantService;

    @RabbitListener(queues = "warehouse_queue", containerFactory = "rabbitListenerContainerFactory")
    public void receiveOrder(OrderDTO order) {
        System.out.println("Received Order: " + order);


        boolean isInStock = verifyStock(order);

        StockVerificationDTO stockVerification = new StockVerificationDTO();
        stockVerification.setOrderId(order.getOrderId());
        stockVerification.setIsInStock(isInStock);

        stockPublisherService.publishStockVerification(stockVerification);
    }

    private boolean verifyStock(OrderDTO order) {
        ProductVariant productVariantOpt = ProductVariantDTO.mapFromDTOToProductVariant(productVariantService.findById(order.getProductVariantId()));

        if (productVariantOpt != null) {
            System.out.println("Product variant found: " + order.getProductVariantId());
            productVariantService.updateQuantity(productVariantOpt.getId(), order.getQuantity());
            return true;
        } else {
            // Handle the case where the product variant is not found
            System.err.println("Product variant not found for ID: " + order.getProductVariantId());
            return false;
        }
    }

}
