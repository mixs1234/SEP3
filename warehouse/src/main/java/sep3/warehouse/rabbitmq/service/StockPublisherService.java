package sep3.warehouse.rabbitmq.service;

import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import sep3.warehouse.rabbitmq.StockVerificationDTO;

@Service
public class StockPublisherService {

    private final RabbitTemplate rabbitTemplate;

    @Value("${warehouse.exchange.name}")
    private String warehouseExchangeName;

    public StockPublisherService(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }

    public void publishStockVerification(StockVerificationDTO stockVerification) {
        String routingKey = "stock.verified";

        rabbitTemplate.convertAndSend(
                warehouseExchangeName,
                routingKey,
                stockVerification
        );

        System.out.println("Sent Stock Verification: " + stockVerification);
    }
}
