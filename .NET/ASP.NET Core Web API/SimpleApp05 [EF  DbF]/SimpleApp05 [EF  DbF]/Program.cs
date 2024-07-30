
using Microsoft.EntityFrameworkCore;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.Repositories;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.Repositories;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.Repositories;
using SimpleApp05__EF__DbF_.DatabaseLayer;

namespace SimpleApp05__EF__DbF_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApbdContext>( opt => opt.UseSqlServer("name=DBString"));
            builder.Services.AddTransient<IClientsRepository, ClientsRepository>();
            builder.Services.AddTransient<ICountriesRepository, CountriesRepository>();
            builder.Services.AddTransient<ITripsRepository, TripsRepository>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
