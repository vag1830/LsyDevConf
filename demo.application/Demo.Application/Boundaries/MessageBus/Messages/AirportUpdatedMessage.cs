using Demo.Application.Domain;

namespace Demo.Application.Boundaries.MessageBus.Messages;

public class AirportUpdatedMessage : Message<AirportPayload>
{
    public AirportUpdatedMessage(Airport payload)
        : base("airportUpdated")
    {
        Payload = new AirportPayload()
        {
            Id = payload.Id,
            IcaoCode = payload.IcaoCode,
            Name = payload.Name
        };
    }
}
