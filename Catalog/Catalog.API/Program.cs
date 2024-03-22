using Catalog.DataAccess;
using Catalog.DataAccess.Interfaces;
using Catalog.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    string connectionString = builder.Configuration["ConnectionStrings:SqlServerConnectionString"];
    options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<CatalogDbContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


// Add services to the container.

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
