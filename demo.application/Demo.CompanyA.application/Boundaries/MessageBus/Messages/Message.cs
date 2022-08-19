namespace Demo.Application.Boundaries.MessageBus.Messages;

public abstract class Message<T>
{
    public Message(string type)
    {
        Type = type;
    }

    public string Type { get; set; }

    public virtual T Payload { get; set; }
}

public interface IMessage
{
    string Type { get; set; }
}
