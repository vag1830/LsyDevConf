using Demo.CompanyB.WebApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/airports", () =>
{
    var airports = Database.GetAllAirports();

    return airports;
})
.WithName("GetAllAirports");

app.MapGet("/airports/{id}", (int id) =>
{
    var airport = Database.GetAirportById(id);

    return airport;
})
.WithName("GetAirportById");

app.MapPost("/airports", ([FromBody] Airport airport) =>
{
    var createdAirport = Database.CreateAirport(airport);


    if (configuration.GetValue<bool>("isEmailEnabled"))
    {
        var emailService = new EmailService(configuration);
        emailService.Send(airport);
    }

    if (configuration.GetValue<bool>("isKafkaEnabled"))
    {
        var kafkaService = new KafkaService(configuration);
        kafkaService.Send(airport);
    }

    return createdAirport;
})
.WithName("Create");

app.Run();