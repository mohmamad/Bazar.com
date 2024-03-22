using Microsoft.EntityFrameworkCore;
using Order.DataAccess;
using Order.DataAccess.Interfaces;
using Order.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(options =>
{
    string connectionString = builder.Configuration["ConnectionStrings:SqlServerConnectionString"];
    options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.AddDbContext<OrderDbContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

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
