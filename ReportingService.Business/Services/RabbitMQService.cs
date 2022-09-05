using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportingService.Business.Models;

namespace ReportingService.Business.Services;

public class RabbitMQService
{
    public Transaction GeTransaction()
    {

        var factory = new ConnectionFactory() { Uri = new Uri("amqp://guest:guest@localhost:5672") };
        using var connection = factory.CreateConnection();
        using var chanel = connection.CreateModel();
        chanel.QueueDeclare("demo-queue",
        durable: true,
        exclusive: false,
        autoDelete: false,
        arguments: null);

        var consumer = new EventingBasicConsumer(chanel);
        var transaction = new Transaction();
        consumer.Received += (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            transaction = JsonSerializer.Deserialize<Transaction>(message);
        };
        chanel.BasicConsume("demo-queue", true, consumer);
        return transaction;
    }
}

