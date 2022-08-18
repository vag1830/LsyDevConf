namespace producer;

public class Airport
{
    public int Id { get; set; }

    public int Revision { get; set; }

    public string? IcaoCode { get; set; }

    public string? DomesticIdent { get; set; }

    public string? Iata { get; set; }

    public string? Name { get; set; }

    public int? CountryId { get; set; }

    public int? CountryIsoId { get; set; }

    public int? StateId { get; set; }

    public string? City { get; set; }

    public string? AirportType { get; set; }

    public string? Elevation { get; set; }

    public string? MagneticVariation { get; set; }

    public string? Remarks { get; set; }
}
