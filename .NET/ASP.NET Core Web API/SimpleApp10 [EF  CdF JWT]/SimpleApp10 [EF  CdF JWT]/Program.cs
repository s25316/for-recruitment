
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer;
using SimpleApp10__EF__CdF_JWT_.Middlewares;
using System.Text;

namespace SimpleApp10__EF__CdF_JWT_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LibraryDBContext>(opt => opt.UseSqlServer("name=DBString1"));
            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository2>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Pleese enter 'Bearer [jwt]'",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
            });

            //Add Here JWT
            builder.Services.AddAuthentication(opt =>
            {
                //Creating Default Scheme [We can use in different Controllers Differnt Scheme]
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //I want validate, Who Give Token
                    ValidateAudience = true,//I want validate, For Who Given Token
                    ValidateLifetime = true,//I want to app not allowed Expired Tokens
                    ClockSkew = TimeSpan.FromMinutes(2),// Time using for EXPIRED tokens TimeSpan.Zero
                    ValidIssuer = builder.Configuration.GetSection("JWT")["Issuer1"],//Who is ISSUER
                    ValidAudience = builder.Configuration.GetSection("JWT")["Audience1"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        builder.Configuration.GetSection("SecretKeys")["SecretKey1"]
                        ?? throw new InvalidOperationException("Secret Not Configured"))),
                };
                //Return info about Expired Token
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Append("Token-expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthenticationWerifier();

            app.MapControllers();

            app.Run();
        }
    }
}
