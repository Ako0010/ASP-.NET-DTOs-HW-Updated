using ASP_.NET_DTOs_HW.Data;
using ASP_.NET_DTOs_HW.Mappings;
using ASP_.NET_DTOs_HW.Services;
using ASP_.NET_DTOs_HW.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var connectionString = builder
                        .Configuration
                        .GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<HWDbContext>(
    options => options.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskFlow API v1");
            options.RoutePrefix = string.Empty;
            options.DisplayRequestDuration();
            options.EnableFilter();
            options.EnableDeepLinking();
            options.EnableTryItOutByDefault();
        }
        );
}

app.UseAuthorization();

app.MapControllers();

app.Run();
