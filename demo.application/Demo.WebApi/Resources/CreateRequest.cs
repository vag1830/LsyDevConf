using Demo.Application.Domain;

namespace Demo.WebApi.Resources
{
    public class CreateRequest
    {
        public string? IcaoCode { get; set; }

        public string? Name { get; set; }

        //public int CountryId { get; set; }

        //public string? City { get; set; }

        //public AirportType AirportType { get; set; }

        //public Elevation? Elevation { get; set; }

        //public MagneticVariation? MagneticVariation { get; set; }
    }
}