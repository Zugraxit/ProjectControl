using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<WebApi.Contexts.DataContext>(options =>
    options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql")));

var urls = builder.Configuration["ApplicationSettings:Urls"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

if (!string.IsNullOrEmpty(urls))
{
    app.Urls.Add(urls); // Слушать URL из конфигурации
}

app.Run();
