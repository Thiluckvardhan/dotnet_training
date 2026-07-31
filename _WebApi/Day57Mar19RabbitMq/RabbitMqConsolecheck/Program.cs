using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

// 1. Connection factory
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};

// 2. Create connection
var connection = factory.CreateConnection();

// 3. Create channel
var channel = connection.CreateModel();

// 4. Declare queue (must match Producer API)
string queueName = "demo.queue";

channel.QueueDeclare(
    queue: queueName,
    durable: true,
    exclusive: false,
    autoDelete: false
);

Console.WriteLine("Waiting for messages...");

// 5. Create consumer
var consumer = new EventingBasicConsumer(channel);

// 6. Define what happens when message arrives
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Received: {message}");
};

// 7. Start consuming
channel.BasicConsume(
    queue: queueName,
    autoAck: true,
    consumer: consumer
);

Console.ReadLine(); // keep app running


//using System.Text;                 // Provides encoding utilities (used to convert byte[] → string)
//using System.Text.Json;            // Used for JSON serialization/deserialization
//using RabbitMQ.Client;             // Core RabbitMQ client (connection, channel, etc.)
//using RabbitMQ.Client.Events;      // Provides event-based consumer (EventingBasicConsumer)

//// Configuration values for connecting and messaging
//const string hostName = "localhost";   // RabbitMQ server address
//const int port = 5672;                // Default RabbitMQ port
//const string userName = "guest";      // Default username
//const string password = "guest";      // Default password
//const string exchangeName = "demo.exchange"; // Exchange where messages are published
//const string queueName = "demo.queue";       // Queue that will store messages
//const string routingKey = "demo.message";    // Routing key used to bind exchange → queue

//// Create a connection factory (this is like a config object for RabbitMQ connections)
//var factory = new ConnectionFactory
//{
//    HostName = hostName,
//    Port = port,
//    UserName = userName,
//    Password = password
//};

//// Open a TCP connection to RabbitMQ server
//using var connection = factory.CreateConnection();

//// Create a channel (lightweight virtual connection inside TCP connection)
//// All operations (declare, publish, consume) happen through a channel
//using var channel = connection.CreateModel();

//// Declare an exchange
//// - Direct exchange routes messages based on exact routing key match
//// - durable: true → survives broker restarts
//channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: true);

//// Declare a queue
//// - durable: true → queue persists after restart
//// - exclusive: false → can be used by multiple connections
//// - autoDelete: false → won’t be deleted automatically when unused
//channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);

//// Bind queue to exchange using routing key
//// This tells RabbitMQ: "Send messages with this routing key to this queue"
//channel.QueueBind(queueName, exchangeName, routingKey);

//// QoS (Quality of Service) settings
//// - prefetchCount: 1 → process one message at a time
//// WHY: prevents consumer from being overwhelmed and ensures fair distribution
//channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

//// Create a consumer that listens for messages
//var consumer = new EventingBasicConsumer(channel);

//// Event handler: runs whenever a message is received
//consumer.Received += (_, ea) =>
//{
//    try
//    {
//        // Convert message body (byte[]) into string
//        var json = Encoding.UTF8.GetString(ea.Body.ToArray());

//        // Deserialize JSON into your strongly-typed object
//        var message = JsonSerializer.Deserialize<RabbitMessage>(json);

//        // If deserialization fails (invalid JSON or structure mismatch)
//        if (message is null)
//        {
//            Console.WriteLine($"[Invalid] Payload: {json}");

//            // Reject message without requeueing
//            // WHY: prevents infinite retry loop for bad data
//            channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
//            return;
//        }

//        // Log the received message
//        Console.WriteLine($"[Received] Id={message.Id} Sender={message.Sender} Text={message.Text} SentAtUtc={message.SentAtUtc:O}");

//        // Acknowledge message (tells RabbitMQ: "processed successfully")
//        // WHY: prevents message from being redelivered
//        channel.BasicAck(ea.DeliveryTag, multiple: false);
//    }
//    catch (Exception ex)
//    {
//        // Catch any runtime errors (e.g., JSON parsing, logic issues)
//        Console.WriteLine($"[Error] Failed to process message: {ex.Message}");

//        // Reject message without requeue
//        // WHY: avoid infinite retry loop for failing messages
//        channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
//    }
//};

//// Start consuming messages from the queue
//// - autoAck: false → manual acknowledgment (gives control & reliability)
//// WHY: ensures messages aren't lost if processing fails
//channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

//// Keep console app alive so it continues listening
//Console.WriteLine("Consumer console is running. Publish from Producer API and watch messages here.");
//Console.WriteLine("Press Enter to exit...");
//Console.ReadLine();

//// Define the message structure expected from RabbitMQ
//// Using record → immutable, concise, ideal for data transfer
//public sealed record RabbitMessage(Guid Id, string Sender, string Text, DateTimeOffset SentAtUtc);