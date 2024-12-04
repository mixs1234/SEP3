package sep3.warehouse.rabbitmq.service;


import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.productVariants.ProductVariantDTO;
import sep3.warehouse.entities.ProductVariant;
import sep3.warehouse.rabbitmq.CreateOrderConfirmationDTO;
import sep3.warehouse.rabbitmq.StockVerificationDTO;
import sep3.warehouse.service.ProductVariantService;

@Service
@RequiredArgsConstructor
public class OrderListenerService {

    private final StockPublisherService stockPublisherService;
    private final ProductVariantService productVariantService;

    @RabbitListener(queues = "warehouse_queue", containerFactory = "rabbitListenerContainerFactory")
    public void receiveOrder(CreateOrderConfirmationDTO order) {
        System.out.println("Received Order: " + order);

        boolean isInStock = true;

        for(long key : order.getProductVariantIdToQuantity().keySet()){
            if(!verifyStock(key, order.getProductVariantIdToQuantity().get(key))){
                isInStock = false;
                break;
            }
        }

        if(isInStock){
            for(long key : order.getProductVariantIdToQuantity().keySet()){
                UpdateStock(key, order.getProductVariantIdToQuantity().get(key));
            }
        }


        StockVerificationDTO stockVerification = new StockVerificationDTO();
        stockVerification.setOrderId(order.getOrderId());
        stockVerification.setInStock(isInStock);

        stockPublisherService.publishStockVerification(stockVerification);
    }

    private boolean verifyStock(long variantId, int quantity) {
        ProductVariant productVariant = ProductVariantDTO.mapFromDTOToProductVariant(productVariantService.findById(variantId));
        System.out.println("Product variant found: " + productVariant.getId());

        if(productVariant.getStock() < quantity) {
                return false;
        }
        return true;
    }

    private void UpdateStock(long variantId, int quantity) {
        productVariantService.updateQuantity(variantId, quantity);
    }

}
