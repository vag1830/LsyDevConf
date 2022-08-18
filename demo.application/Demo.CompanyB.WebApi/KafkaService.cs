using Confluent.Kafka;

namespace Demo.CompanyB.WebApi;

public class KafkaService
{
    private readonly IConfiguration configuration;

    public KafkaService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Send(Airport airport)
    {
        var kafkaMessage = new Message<string, string>
        {
            Key = "airportCreated",
            Value = Newtonsoft.Json.JsonConvert.SerializeObject(airport)
        };

        Send(configuration.GetValue<string>("topic"), kafkaMessage);
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
        { "bootstrap.servers", configuration.GetValue<string>("kafkaEndpoint") }
    };

        var builder = new ProducerBuilder<string, string>(config);

        builder.SetValueSerializer(Serializers.Utf8);

        return builder.Build();
    }

}
