using Microsoft.EntityFrameworkCore;
using WebShop;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShop.Services;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDbContext")));

builder.Services.AddControllers();
// Registrera Unit of Work i DI-container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICustomerRepository<CustomerEntity>, CustomerRepository>();
builder.Services.AddScoped<IProductRepository<ProductEntity>, ProductRepository>();

builder.Services.AddTransient<INotificationObserver, EmailNotification>();
builder.Services.AddTransient<INotificationObserver, SmsNotification>();

builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
