using FluentValidation.AspNetCore;
using Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidarityBlood.API.Filters;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Application.Validators.Donors;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Persistence;
using SolidarityBlood.Infrastructure.Persistence.Repositories;
using SolidarityBlood.Infrastructure.Integration.Refit;
using SolidarityBlood.Infrastructure.Integration.Interfaces;
using SolidarityBlood.Infrastructure.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateDonorValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  ==== CONFIGURATIONS ====

var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<SolidarityBloodDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(CreateDonorCommand)));

// estou arriscando nisso na verdade
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; 
});

builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br/");
});

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
