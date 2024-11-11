package sep3.warehouse.rabbitmq.service;


import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;
import sep3.warehouse.rabbitmq.OrderDTO;
import sep3.warehouse.rabbitmq.StockVerificationDTO;

@Service
public class OrderListenerService {

    private final StockPublisherService stockPublisherService;

    public OrderListenerService(StockPublisherService stockPublisherService) {
        this.stockPublisherService = stockPublisherService;
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

        return true;
    }
}
