using Microsoft.EntityFrameworkCore;
using MobilidadeAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MobilidadeDb")
);

builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Swagger sempre disponível
app.UseSwagger();
app.UseSwaggerUI();

// Middlewares
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
