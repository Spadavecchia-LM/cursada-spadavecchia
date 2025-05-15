
using Microsoft.EntityFrameworkCore;
using parcial1.EF;
using parcial1.Interfaces;
using parcial1.Repositories;

namespace parcial1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration["MYSQL_CONNECTION_STRING"];
            builder.Services.AddDbContext<MiDBContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



            builder.Services.AddScoped<ITitularRepository, TitularRepository>();
            builder.Services.AddScoped<ITramiteRepository, TramiteRepository>();
            builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

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
        }
    }
}
