using System.Text;
using System.Text.Json;
using CartApi.Models.Contracts;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace CartApi.Messaging;

public class CartEventPublisher
{
    public const string ExchangeName = "cart.exchange";
    public const string RoutingKey = "cart.checkedout";

    private readonly RabbitMqSettings _settings;

    public CartEventPublisher(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }

    public void PublishCartCheckedOut(CartCheckedOut cartCheckedOut)
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            Port = _settings.Port,
            UserName = _settings.UserName,
            Password = _settings.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(
            exchange: ExchangeName,
            type: ExchangeType.Direct,
            durable: true,
            autoDelete: false);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(cartCheckedOut));
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: ExchangeName,
            routingKey: RoutingKey,
            basicProperties: properties,
            body: body);
    }
}
