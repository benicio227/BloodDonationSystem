using BloodDonationSystem.Api.ExceptionHandler;
using BloodDonationSystem.Application.Commands.InsertDonor;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Persistence;
using BloodDonationSystem.Infrastucture.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("BloodDonationSystemCs");
builder.Services.AddDbContext<BloodDonationSystemDbContext>(o => o.UseSqlServer(connectionString));


builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertDonorCommand>());

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InsertDonorCommand>();

builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

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

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
