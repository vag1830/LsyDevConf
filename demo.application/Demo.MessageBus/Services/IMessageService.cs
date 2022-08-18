using Demo.Application.Boundaries.MessageBus.Messages;

namespace Demo.MessageBus.Services;

public interface IMessageService
{
    void Send<T>(Message<T> message);
}
