using System.Text;
using System.Text.Json;
using CartApi.Models.Contracts;
using CartApi.Services;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CartApi.Messaging;

public class ProductSelectedConsumer : BackgroundService
{
    public const string ExchangeName = "product.exchange";
    public const string QueueName = "cart.product.selected.queue";
    public const string RoutingKey = "product.selected";

    private readonly RabbitMqSettings _settings;
    private readonly CartService _cartService;
    private readonly ILogger<ProductSelectedConsumer> _logger;

    public ProductSelectedConsumer(
        IOptions<RabbitMqSettings> settings,
        CartService cartService,
        ILogger<ProductSelectedConsumer> logger)
    {
        _settings = settings.Value;
        _cartService = cartService;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => Consume(stoppingToken), stoppingToken);
    }

    private void Consume(CancellationToken stoppingToken)
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

        channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Direct, durable: true, autoDelete: false);
        channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false);
        channel.QueueBind(queue: QueueName, exchange: ExchangeName, routingKey: RoutingKey);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (_, ea) =>
        {
            try
            {
                var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                var message = JsonSerializer.Deserialize<ProductSelected>(json);

                if (message is not null)
                {
                    _cartService.ProductSelect(message);
                }

                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process ProductSelected event.");
                channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
            }
        };

        channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);

        while (!stoppingToken.IsCancellationRequested)
        {
            Thread.Sleep(500);
        }
    }
}
