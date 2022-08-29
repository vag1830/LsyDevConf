using Demo.Application.Domain;

namespace Demo.Application.Airports.GetAll;

public interface IGetAllUseCase
{
    Task<List<Airport>> Execute();
}
