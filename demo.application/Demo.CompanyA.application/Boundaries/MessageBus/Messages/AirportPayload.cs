namespace Demo.Application.Boundaries.MessageBus.Messages;

public class AirportPayload
{
    public int Id { get; set; }

    public string? IcaoCode { get; set; }

    public string? Name { get; set; }
}
