using sep3.broker.Model;
using sep3.broker.Services;

namespace brokers.broker;

public interface IStatusBroker
{
    Task<Result<string>> GetStatusesAsync();
}