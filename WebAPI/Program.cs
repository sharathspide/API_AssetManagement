using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebAPI.BusinessLayer;
using WebAPI.Data;
using WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Establishing the connection to the DB connection using DBContext Service
builder.Services.AddDbContext<AssetsDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// AddScoped service is used becuase the instance of the service will be created per request and shared only within the request scope.
// AddSingleton service is used because the instance of the service will be created once and shared across all requests.
// AddTransient service is used because the instance of the service will be created each time it is requested. (not suitable for large scale applications as it can lead to performance issues and increased memory usage)
builder.Services.AddScoped<IAssetManagementService, AssetManagementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
