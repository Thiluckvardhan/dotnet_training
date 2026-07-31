using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PaymentApi.Models.Contracts;
using PaymentApi.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PaymentApi.Messaging;

public class CartCheckedOutConsumer : BackgroundService
{
    public const string ExchangeName = "cart.exchange";
    public const string QueueName = "payment.cart.checkedout.queue";
    public const string RoutingKey = "cart.checkedout";

    private readonly RabbitMqSettings _settings;
    private readonly PaymentService _paymentService;
    private readonly ILogger<CartCheckedOutConsumer> _logger;

    public CartCheckedOutConsumer(
        IOptions<RabbitMqSettings> settings,
        PaymentService paymentService,
        ILogger<CartCheckedOutConsumer> logger)
    {
        _settings = settings.Value;
        _paymentService = paymentService;
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
                var message = JsonSerializer.Deserialize<CartCheckedOut>(json);

                if (message is not null)
                {
                    _paymentService.Process(message);
                }

                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process CartCheckedOut event.");
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
