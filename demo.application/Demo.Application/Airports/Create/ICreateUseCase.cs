using Demo.Application.Airports.Create.Parameters;
using Demo.Application.Domain;

namespace Demo.Application.Airports.Create;

public interface ICreateUseCase
{
    Task<Airport> Execute(CreateInput input);
}
