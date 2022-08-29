using Demo.Application.Domain;

namespace Demo.Application.Boundaries.MessageBus.Messages;

public class AirportCreatedMessage : Message<AirportPayload>
{
    public AirportCreatedMessage(Airport payload)
        : base("airportCreated")
    {
        Payload = new AirportPayload()
        {
            Id = payload.Id,
            IcaoCode = payload.IcaoCode,
            Name = payload.Name
        };
    }
}
