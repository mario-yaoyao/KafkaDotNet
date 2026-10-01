using Confluent.Kafka;
using KafkaDotNet.ProducerBLL.Interfaces;
using Microsoft.Extensions.Logging;

namespace KafkaDotNet.ProducerBLL.Services
{
    public class ProducerService(ILogger<ProducerService> logger) : IProducerService
    {
        public async Task ProduceAsync(CancellationToken cancellationToken)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var message = new Message<Null, string> { Value = "Hello, Kafka!" };
                var deliveryResult = await producer.ProduceAsync(topic: "test-topic", message, cancellationToken);
                logger.LogInformation($"Delivered message to {deliveryResult.Value}, Offset: {deliveryResult.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                logger.LogError($"Delivery failed: {e.Error.Reason}");
            }

            producer.Flush(cancellationToken);
        }
    }
}
