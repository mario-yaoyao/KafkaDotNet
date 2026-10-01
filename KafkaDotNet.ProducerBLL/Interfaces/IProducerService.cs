namespace KafkaDotNet.ProducerBLL.Interfaces
{
    public interface IProducerService
    {
        Task ProduceAsync(CancellationToken cancellationToken);
    }
}
