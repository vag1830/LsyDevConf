using Demo.Application.Boundaries.MessageBus.Messages;

namespace Demo.Application.Boundaries.MessageBus;

public interface IMessageBus
{
    void Send<T>(Message<T> message);
}
