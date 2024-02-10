using Cocona;
using dmq.Commands;
using dmq.Configuations;
using dmq.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IWeatherService, OpenWeatherMapService>();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .AddJsonFile("appSettings.dev.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.Configure<AqicnOptions>(configuration.GetSection(nameof(AqicnOptions)));

var app = builder.Build();

app.AddCommands<WeatherCommands>();

app.Run();