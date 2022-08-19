using Demo.Application.Airports.Update.Parameters;
using Demo.Application.Boundaries.Database;
using Demo.Application.Boundaries.MessageBus;
using Demo.Application.Boundaries.MessageBus.Messages;
using Demo.Application.Domain;

namespace Demo.Application.Airports.Update;

public class UpdateUseCase : IUpdateUseCase
{
    private readonly IAirportRepository repository;
    private readonly IMessageBus messageBus;

    public UpdateUseCase(
        IAirportRepository repository,
        IMessageBus messageBus)
    {
        this.repository = repository;
        this.messageBus = messageBus;
    }

    public async Task<Airport> Execute(int id, UpdateInput input)
    {
        var airport = await repository.GetById(id);

        if (airport == null)
        {
            throw new Exception($"Airport with Id: {id}, was not found");
        }

        airport.Name = input.Name;
        airport.IcaoCode = input.IcaoCode;

        await repository.Update(airport);

        var message = new AirportUpdatedMessage(airport);

        messageBus.Send(message);

        return airport;
    }
}
