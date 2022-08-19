namespace Demo.MessageBus.Services;

public delegate IList<IMessageService> MessageServiceResolver(string type);
