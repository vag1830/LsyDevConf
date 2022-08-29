namespace Demo.WebApi.Airports;

public class CreateResponse
{
    public int Id { get; set; }

    public string? IcaoCode { get; set; }

    public string? Name { get; set; }
}