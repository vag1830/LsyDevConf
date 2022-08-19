using Demo.Application.Boundaries.MessageBus.Messages;

namespace Demo.MessageBus.Services;

public interface IMessageServiceFactory
{
    void Send<T>(Message<T> message);
}
