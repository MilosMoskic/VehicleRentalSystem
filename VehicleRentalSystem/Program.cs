using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VehicleRentalSystem.Commands;
using VehicleRentalSystem.Data;
using VehicleRentalSystem.Interfaces;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.Services;

var builder = CoconaApp.CreateBuilder();

builder.Logging.AddFilter("System.Net.Http", LogLevel.Warning);
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IRentCommands, RentCommands>();
builder.Services.AddScoped<IRentModel, RentModel>();
builder.Services.AddScoped<IVehicleData, VehicleData>();

var app = builder.Build();

app.AddCommand("PrintCar", (IRentCommands rentCommands) =>
{
    var rents = rentCommands.PrintCar();
    Console.WriteLine(rents);
});

app.AddCommand("PrintMotorcycle", (IRentCommands rentCommands) =>
{
    var rents = rentCommands.PrintMotorcycle();
    Console.WriteLine(rents);
});

app.AddCommand("PrintCargoVan", (IRentCommands rentCommands) =>
{
    var rents = rentCommands.PrintCargoVan();
    Console.WriteLine(rents);
});

app.Run();