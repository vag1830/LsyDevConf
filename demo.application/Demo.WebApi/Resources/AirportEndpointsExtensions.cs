using Demo.Application.Airports.Create;
using Demo.Application.Airports.Create.Parameters;
using Demo.Application.Airports.GetAll;
using Demo.Application.Airports.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Resources
{
    public static class AirportEndpointsExtensions
    {
        public static WebApplication AddAirportEndpoints(this WebApplication app) 
        {
            return app
                .AddGetAll()
                .AddGetById()
                .AddCreateUseCase();
        }

        private static WebApplication AddGetAll(this WebApplication app)
        {
            app.MapGet("/airports", async ([FromServices] IGetAllUseCase useCase) =>
            {
                var result = await useCase.Execute();

                return Results.Ok(result);
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
                    var result = await useCase.Execute(id);

                    return Results.Ok(result);
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
            app.MapPost("/airports", async ([FromServices] ICreateUseCase useCase, [FromBody]CreateRequest request) =>
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
            .WithName("Create");

            return app;
        }
    }
}
