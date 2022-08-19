using Demo.Application.Boundaries.Database;
using Demo.Application.Domain;

namespace Demo.Database;

public class AirportRepository : IAirportRepository
{
    public async Task<List<Airport>> GetAll()
    {
        return await Task.FromResult(Airports);
    }

    public async Task<Airport?> GetById(int id)
    {
        var result = Airports
            .FirstOrDefault(airport => airport.Id == id);

        return await Task.FromResult(result);
    }

    public async Task Add(Airport airport)
    {
        airport.Id = Airports.Count + 1;

        Airports.Add(airport);

        await Task.CompletedTask;
    }

    public async Task Update(Airport airport)
    {
        var existingAirport = Airports.First(a => a.Id == airport.Id);

        existingAirport = airport;

        await Task.CompletedTask;
    }

    private List<Airport> Airports = new List<Airport> {
            new Airport {
                Id = 1,
                IcaoCode = "LSZH",
                Name = "Zurich"
            },
            new Airport {
                Id = 2,
                IcaoCode = "LGAV",
                Name = "Athens International Airport, Eleftherios Venizelos"
            }
        };
}
