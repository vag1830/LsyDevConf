using Demo.Application.Boundaries.Configuration;
using Demo.WebApi.Airports;
using Demo.WebApi.DIExtensions;
using Demo.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var configurationService = new ConfigurationService(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAirportUseCases();
builder.Services.AddMessageBusServices(configurationService);

builder.Services.AddScoped<IConfigurationService>(_ => configurationService);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddAirportEndpoints();

app.Run();
