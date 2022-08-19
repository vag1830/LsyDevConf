using Demo.Application.Airports.Create.Parameters;
using Demo.Application.Boundaries.Database;
using Demo.Application.Boundaries.MessageBus;
using Demo.Application.Boundaries.MessageBus.Messages;
using Demo.Application.Domain;

namespace Demo.Application.Airports.Create;

public class CreateUseCase : ICreateUseCase
{
    private readonly IAirportRepository repository;
    private readonly IMessageBus messageBus;

    public CreateUseCase(
        IAirportRepository repository,
        IMessageBus messageBus)
    {
        this.repository = repository;
        this.messageBus = messageBus;
    }

    public async Task<Airport> Execute(CreateInput input)
    {
        Airport airport = new()
        {
            IcaoCode = input.IcaoCode,
            Name = input.Name
        };

        await repository.Add(airport);

        var message = new AirportCreatedMessage(airport);

        messageBus.Send(message);

        return airport;
    }
}
