namespace Demo.WebApi.Airports;

public class CreateRequest
{
    public string? IcaoCode { get; set; }

    public string? Name { get; set; }
}