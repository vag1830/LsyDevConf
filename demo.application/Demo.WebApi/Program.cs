using System.Text.Json.Serialization;
using Demo.Application.Boundaries.Configuration;
using Demo.WebApi.DIExtensions;
using Demo.WebApi.Resources;
using Demo.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.Configure<JsonOptions>(options => 
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAirportUseCases();
builder.Services.AddMessageBusServices(new ConfigurationService(configuration));

builder.Services.AddScoped<IConfigurationService>(_ => new ConfigurationService(configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddAirportEndpoints();

app.Run();
