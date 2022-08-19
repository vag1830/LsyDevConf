namespace Demo.CompanyB.WebApi;

public class Database
{
    public static List<Airport> GetAllAirports()
    {
        return Airports;
    }

    public static Airport GetAirportById(int id)
    {
        return Airports.First(a => a.Id == id);
    }

    public static Airport CreateAirport(Airport airport)
    {
        var id = Airports.Count + 1;
        airport.Id = id;

        Airports.Add(airport);

        return airport;
    }

    private static readonly List<Airport> Airports = new() {
            new Airport {
                Id = 1,
                Icao = "LSZH",
                Name = "Zurich"
            },
            new Airport {
                Id = 2,
                Icao = "LGAV",
                Name = "Athens International Airport, Eleftherios Venizelos"
            }
        };
}
