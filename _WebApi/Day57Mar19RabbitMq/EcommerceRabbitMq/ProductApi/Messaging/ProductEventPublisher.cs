using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ProductApi.Models.Contracts;
using RabbitMQ.Client;

namespace ProductApi.Messaging;

public class ProductEventPublisher
{
    public const string ExchangeName = "product.exchange";
    public const string RoutingKey = "product.selected";

    private readonly RabbitMqSettings _settings;

    public ProductEventPublisher(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }

    public void PublishProductSelected(ProductSelected productSelected)
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

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(productSelected));
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: ExchangeName,
            routingKey: RoutingKey,
            basicProperties: properties,
            body: body);
    }
}
