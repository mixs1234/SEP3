namespace brokers.broker.MessageQueue;

using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class MessageQueueService
{
    private readonly ConcurrentQueue<OrderMessage> _queue = new ConcurrentQueue<OrderMessage>();
    private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);

    public void EnqueueMessage(OrderMessage message)
    {
        _queue.Enqueue(message);
        _signal.Release();
    }

    public async Task<OrderMessage> DequeueMessageAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        _queue.TryDequeue(out var message);
        return message;
    }
}
