using FluentValidation;
using MediatorExample.Features.Handlers;
using MediatorExample.Features.Validators;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR registration
Assembly[] assemblyList = { Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(HelloWorldHandler)) };
builder.Services.AddMediatR(assemblyList);

// Validator registration
builder.Services.AddValidatorsFromAssemblyContaining<HelloPersonRequestValidator>();

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
