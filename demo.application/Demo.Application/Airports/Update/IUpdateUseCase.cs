using Demo.Application.Airports.Update.Parameters;
using Demo.Application.Domain;

namespace Demo.Application.Airports.Update;

public interface IUpdateUseCase
{
    Task<Airport> Execute(int id, UpdateInput input);
}
