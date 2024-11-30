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
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                         ?? builder.Configuration.GetConnectionString("WebShopDbContext")));

builder.Services.AddScoped<IWebShopDbContext>(provider => provider.GetRequiredService<WebShopDbContext>());

builder.Services.AddControllers();
// Registrera Unit of Work i DI-container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICustomerRepository<CustomerEntity>, CustomerRepository>();
builder.Services.AddScoped<IProductRepository<ProductEntity>, ProductRepository>();
builder.Services.AddScoped<IOrderDetailsRepository<OrderDetailEntity>, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository<OrderEntity>, OrderRepository>();

builder.Services.AddTransient<INotificationObserver, EmailNotification>();
builder.Services.AddTransient<INotificationObserver, SmsNotification>();

builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WebShopDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebShop API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


{
}
