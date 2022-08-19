using Demo.Application.Domain;

namespace Demo.Application.Boundaries.Database;

public interface IAirportRepository
{
    Task<List<Airport>> GetAll();

    Task<Airport?> GetById(int id);

    Task Add(Airport airport);

    Task Update(Airport airport);
}
