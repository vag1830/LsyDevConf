using Demo.Application.Domain;

namespace Demo.Application.Airports.GetById;

public interface IGetByIdUseCase
{
    Task<Airport> Execute(int id);
}
