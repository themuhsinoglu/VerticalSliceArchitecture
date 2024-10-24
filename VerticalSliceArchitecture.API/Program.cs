using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.API.Applications.Abstracts;
using VerticalSliceArchitecture.API.Applications.Extensions;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Contexts;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var postgresConnectionString = builder.Configuration.GetConnectionString("PsqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseNpgsql(postgresConnectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseInMemoryDatabase("example-db"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.AddEndpoints();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}