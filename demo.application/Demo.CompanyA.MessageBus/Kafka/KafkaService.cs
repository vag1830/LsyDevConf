using Confluent.Kafka;
using Demo.Application.Boundaries.Configuration;
using Demo.Application.Boundaries.MessageBus.Messages;
using Demo.MessageBus.Services;

namespace Demo.MessageBus.Kafka;

public class KafkaService : IMessageService
{
    private readonly IConfigurationService configurationService;

    public KafkaService(IConfigurationService configurationService)
    {
        this.configurationService = configurationService;
    }

    public void Send<T>(Message<T> message)
    {
        var configuration = configurationService.Get<KafkaConfiguration>(message.Type);

        var kafkaMessage = new Message<string, string>
        {
            Key = message.Type,
            Value = Newtonsoft.Json.JsonConvert.SerializeObject(message)
        };

        Send(configuration.Topic, kafkaMessage);
    }

    private void Send(string topic, Message<string, string> message)
    {
        using var producer = CreateProducer();

        producer.Produce(topic, message, deliveryReport =>
        {
            if (deliveryReport.Error.Code != ErrorCode.NoError)
            {
                Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
            }
        });

        producer.Flush(TimeSpan.FromSeconds(10));

        Console.WriteLine($"Message was produced to topic {topic}");
    }

    private IProducer<string, string> CreateProducer()
    {
        var config = new Dictionary<string, string>() {
            { "bootstrap.servers", configurationService.Get<string>("kafkaEndpoint") }
        };

        var builder = new ProducerBuilder<string, string>(config);

        builder.SetValueSerializer(Serializers.Utf8);

        return builder.Build();
    }
}
