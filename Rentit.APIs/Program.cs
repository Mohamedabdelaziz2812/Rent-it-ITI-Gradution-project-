
using Microsoft.EntityFrameworkCore;
using Rentit.BL;
using Rentit.DAL;

namespace Rentit.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string? connectionString = builder.Configuration.GetConnectionString("con1");

            builder.Services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IPropertyRepo,PropertyRepo>();

            builder.Services.AddScoped<IPropertyManager,PropertyManager>();

            builder.Services.AddScoped<IRequestHostRepo, RequestHostRepo>();

            builder.Services.AddScoped<IRequestHostManger,RequestHostManager>(); 
            
            builder.Services.AddScoped<IRequestRentRepo, RequestRentRepo>();  
            
            builder.Services.AddScoped<IRequestRentManager, RequestRentManager>();  

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
        }
    }
}
