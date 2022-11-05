using Integrations.Pokemon.Config;
using Integrations.Pokemon.Interfaces;
using Integrations.Pokemon.Services;
using PokemonFinder.Core.Clients.Implementations;
using PokemonFinder.Core.Clients.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PokeApiConfig>(builder.Configuration.GetSection(typeof(PokeApiConfig).Name));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IRestClient, RestClient>();
builder.Services.AddSingleton<IPokemonService, PokemonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
