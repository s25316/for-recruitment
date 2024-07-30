
using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.Repositories;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.Repositories;
using SimpleApp09__EF__CdF_.DatabaseLayer;

namespace SimpleApp09__EF__CdF_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MusicDBContext>( opt => 
            {
                opt.UseSqlServer("name=DBString");
            });
            builder.Services.AddTransient<IMusicianRepository,MusicianRepository>();
            builder.Services.AddTransient<ISongsRepository,SongsRepository>();
            builder.Services.AddTransient<IAlbumRepository,AlbumRepository>();
            builder.Services.AddTransient<ILabelRepository,LabelRepository>();

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
