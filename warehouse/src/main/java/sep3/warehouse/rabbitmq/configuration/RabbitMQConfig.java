package sep3.warehouse.rabbitmq.configuration;

import org.springframework.amqp.core.*;
import org.springframework.amqp.support.converter.Jackson2JsonMessageConverter;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class RabbitMQConfig {

    @Value("${order.exchange.name}")
    private String orderExchangeName;

    @Bean
    public TopicExchange orderExchange() {
        return new TopicExchange(orderExchangeName, true, false);
    }

    @Bean
    public Queue warehouseQueue() {
        return QueueBuilder.durable("warehouse_queue").build();
    }

    @Bean
    public Jackson2JsonMessageConverter jsonMessageConverter() {
        return new Jackson2JsonMessageConverter();
    }

    @Bean
    public Binding warehouseBinding() {
        return BindingBuilder.bind(warehouseQueue())
                .to(orderExchange())
                .with("order.created");
    }

    @Value("${warehouse.exchange.name}")
    private String warehouseExchangeName;

    @Bean
    public TopicExchange warehouseExchange() {
        return new TopicExchange(warehouseExchangeName, true, false);
    }

}
