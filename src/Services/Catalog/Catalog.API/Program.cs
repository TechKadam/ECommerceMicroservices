using BuildingBlocks.Extensions.CarterLibraryExtensions;
using Mediator.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the contain
builder.Services.AddCarterFromAssembly(typeof(Program).Assembly);
builder.Services.AddMediator(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();


// Configure the HTTP request pipeline
app.MapCarter();
app.Run();
