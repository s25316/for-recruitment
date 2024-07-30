
using Microsoft.EntityFrameworkCore;
using SimpleApp06__EF__CdF_.BusinessLogicLayer;
using SimpleApp06__EF__CdF_.DatabaseLayer;

namespace SimpleApp06__EF__CdF_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>( opt => {opt.UseSqlServer("name=LocalDbStriong");});
            builder.Services.AddTransient<ICarsRepository, CarsRepository> ();

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
