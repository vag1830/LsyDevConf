﻿namespace Demo.CompanyB.WebApi
{
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

        private static List<Airport> Airports = new List<Airport> {
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
}