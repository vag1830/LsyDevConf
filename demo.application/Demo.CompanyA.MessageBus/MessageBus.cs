using Demo.Application.Boundaries.MessageBus;
using Demo.Application.Boundaries.MessageBus.Messages;
using Demo.MessageBus.Services;

namespace Demo.MessageBus;

public class MessageBus : IMessageBus
{
    private readonly MessageServiceResolver messageServiceResolver;

    public MessageBus(MessageServiceResolver messageServiceResolver)
    {
        this.messageServiceResolver = messageServiceResolver;
    }

    public void Send<T>(Message<T> message)
    {
        var services = messageServiceResolver(message.Type).ToList();

        services.ForEach(service => service.Send(message));
    }
}
