package sep3.warehouse.rabbitmq.service;


import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;
import sep3.warehouse.rabbitmq.OrderDTO;
import sep3.warehouse.rabbitmq.StockVerificationDTO;
import sep3.warehouse.service.ProductVariantService;

@Service
public class OrderListenerService {

    private final StockPublisherService stockPublisherService;
    private final ProductVariantService productVariantService;

    public OrderListenerService(StockPublisherService stockPublisherService, ProductVariantService productVariantService) {
        this.stockPublisherService = stockPublisherService;
        this.productVariantService = productVariantService;
    }

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
        int currentStock = productVariantService.findById(Long.parseLong(order.getProductVariantId())).get().getStock();
        productVariantService.updateQuantity(Long.parseLong(order.getProductVariantId()), currentStock-1);

        return true;
    }
}
