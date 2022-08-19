using Demo.Application.Airports.Create;
using Demo.Application.Airports.Create.Parameters;
using Demo.Application.Airports.GetAll;
using Demo.Application.Airports.GetById;
using Demo.Application.Airports.Update;
using Demo.Application.Airports.Update.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Airports;

public static class AirportEndpointsExtensions
{
    public static WebApplication AddAirportEndpoints(this WebApplication app)
    {
        return app
            .AddGetAll()
            .AddGetById()
            .AddCreateUseCase()
            .AddUpdateUseCase();
    }

    private static WebApplication AddGetAll(this WebApplication app)
    {
        app.MapGet("/airports", async ([FromServices] IGetAllUseCase useCase) =>
        {
            var response = await useCase.Execute();

            return Results.Ok(response);
        })
        .WithName("GetAllAirports");

        return app;
    }

    private static WebApplication AddGetById(this WebApplication app)
    {
        app.MapGet("/airports/{id}", async ([FromServices] IGetByIdUseCase useCase, int id) =>
        {
            try
            {
                var response = await useCase.Execute(id);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }

        })
        .WithName("GetAirportById");

        return app;
    }

    private static WebApplication AddCreateUseCase(this WebApplication app)
    {
        app.MapPost("/airports", async ([FromServices] ICreateUseCase useCase, [FromBody] CreateRequest request) =>
        {
            var input = new CreateInput
            {
                IcaoCode = request.IcaoCode,
                Name = request.Name
            };

            var airport = await useCase.Execute(input);

            var response = new CreateResponse()
            {
                Id = airport.Id,
                IcaoCode = airport.IcaoCode,
                Name = airport.Name
            };

            return Results.Created($"/airports/{response.Id}", response);
        })
        .WithName("CreateAirport");

        return app;
    }

    private static WebApplication AddUpdateUseCase(this WebApplication app)
    {
        app.MapPut("/airports/{id}", async (
            [FromServices] IUpdateUseCase useCase,
            int id,
            [FromBody] UpdateRequest request) =>
        {
            try
            {
                var input = new UpdateInput
                {
                    IcaoCode = request.IcaoCode,
                    Name = request.Name
                };

                var airport = await useCase.Execute(id, input);

                var response = new UpdateResponse()
                {
                    Id = airport.Id,
                    IcaoCode = airport.IcaoCode,
                    Name = airport.Name
                };

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("UpdateAirport");

        return app;
    }
}
