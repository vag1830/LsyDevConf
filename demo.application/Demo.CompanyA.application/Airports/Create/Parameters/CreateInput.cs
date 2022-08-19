using Demo.Application.Domain;

namespace Demo.Application.Airports.Create.Parameters;

public class CreateInput
{
    public string? IcaoCode { get; set; }

    public string? Name { get; set; }
}
