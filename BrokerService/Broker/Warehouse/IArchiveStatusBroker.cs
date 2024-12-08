using sep3.broker.Services;

namespace sep3.brokers.broker;

public interface IArchiveStatusBroker
{
    Task<Result<string>> GetAllArchiveStatusAsync();
}