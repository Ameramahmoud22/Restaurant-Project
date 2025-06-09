using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestaurantSystem.Infrastructure.Data;
using RestaurantSystem.Services.Services; 
using RestaurantSystem.API.Middleware;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Services;

namespace RestaurantSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Dependency injection for DbContext
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register services for dependency injection
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();


            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RestaurantSystem API",
                    Version = "v1",
                    Description = "API for managing the Restaurant System",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name",
                        Email = "your.email@example.com"
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantSystem API V1");
                    c.RoutePrefix = string.Empty; // Open Swagger UI at root (e.g., https://localhost:<port>/)
                });
            }

            app.UseExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}