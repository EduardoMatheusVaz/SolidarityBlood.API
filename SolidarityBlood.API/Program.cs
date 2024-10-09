using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Application.Services.Implementations;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IBloodStockService, BloodStockService>();
builder.Services.AddScoped<IAddressService, AddressService>();

var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<SolidarityBloodDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
