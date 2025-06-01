
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Infrastructure.Data;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Services.Services;
using RestaurantSystem.Services;
using RestaurantSystem.API.Middleware;

namespace RestaurantSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //dependency injection for services (DI) => This tells the DI system: “When something needs a RestaurantDbContext, create and provide it.”
            // This is a scoped service, meaning a new instance is created for each request.
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register services(interfaces) for dependency injection
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

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
            app.UseExceptionMiddleware();

            app.UseAuthorization();


            app.MapControllers();
            app.MapGet("/", () => "RestaurantSystem API is running.");

            app.Run();
        }
    }
}
