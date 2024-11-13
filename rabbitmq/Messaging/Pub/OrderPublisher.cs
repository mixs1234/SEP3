using Newtonsoft.Json.Serialization;
using rabbitmq.Model;

namespace rabbitmq.Messaging.Pub;

using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

public class OrderPublisher
{
    private const string ExchangeName = "order_topic_exchange";

    public async Task PublishOrder(OrderDTO order)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        
        Console.WriteLine(factory.HostName);
        
        await channel.ExchangeDeclareAsync(
            exchange: ExchangeName,
            type: ExchangeType.Topic,
            durable: true
            );
        
        var message = JsonConvert.SerializeObject(order, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        var body = Encoding.UTF8.GetBytes(message);
        
        const string routingKey = "order.created";
        
        await channel.BasicPublishAsync(exchange: ExchangeName, routingKey: routingKey, body: body);
        
        Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
    }
}
