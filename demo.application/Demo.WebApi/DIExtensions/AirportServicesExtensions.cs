using Demo.Application.Airports.Create;
using Demo.Application.Airports.GetAll;
using Demo.Application.Airports.GetById;
using Demo.Application.Airports.Update;
using Demo.Application.Boundaries.Database;
using Demo.Database;

namespace Demo.WebApi.DIExtensions;

public static class AirportServicesExtensions
{
    public static IServiceCollection AddAirportUseCases(this IServiceCollection services)
    {

        services.AddScoped<IGetAllUseCase, GetAllUseCase>();
        services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
        services.AddScoped<ICreateUseCase, CreateUseCase>();
        services.AddScoped<IUpdateUseCase, UpdateUseCase>();

        services.AddSingleton<IAirportRepository, AirportRepository>();

        return services;
    }
}
