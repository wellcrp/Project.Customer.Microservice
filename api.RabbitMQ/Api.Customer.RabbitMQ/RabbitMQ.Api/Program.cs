using FluentValidation.AspNetCore;
using RabbitMQ.Api.Filters;
using RabbitMQ.Application.Validators.Customer;
using RabbitMQ.infrastructure.IOC.InjectionContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
        .AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)))
        .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CustomerPublishValidator>());

builder.Services.RegisterApplicationService(builder.Configuration);

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
