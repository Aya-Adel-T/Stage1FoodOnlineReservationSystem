
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1
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
            builder.Services.AddDbContext<ElDbContext>(op => op.UseSqlServer(
                builder.Configuration.GetConnectionString("MyConn1")
                ));
            builder.Services.AddScoped<IRepository<Category>, CategoryServ>();
            builder.Services.AddScoped<IRepository<FoodServed>, FoodServedRepoService>();


            //AddCors ^&*%^&$%^&#$%^#^
            builder.Services.AddCors(p=>p.AddPolicy("corspolicy",build =>
            {
                build.WithOrigins("https://localhost:7007").AllowAnyMethod().AllowAnyHeader();

            }));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //AddCors Name ^&*%^&$%^&#$%^#^
            app.UseCors("corspolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}