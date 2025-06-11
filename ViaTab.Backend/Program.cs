using Microsoft.EntityFrameworkCore;
using ViaTab.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add PostgreSQL with environment variable
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") 
    ?? "Host=localhost;Port=5433;Database=viatab;Username=postgres;Password=postgres123";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
app.MapControllers();


// Auto-create database and seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


app.Run();