

using IMS.BusinessService;
using IMS.BusinessService.Common;
using IMS.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace IMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.AddHttpContextAccessor();

            builder.Services.ConfigureInfrastructureServices(configuration);
            builder.Services.ConfigureIdentityServices(configuration);
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(configuration);

            builder.Services.Configure<JwtSetting>(configuration.GetSection("JwtSettings"));

            var IMSCorsPolicy = "IMSCorsPolicy";
            builder.Services.AddCors(o => o.AddPolicy(IMSCorsPolicy, builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["AllowedOrigins"])
                    .AllowCredentials();
            }));
            builder.Services.ConfigureSettingServices(configuration);
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // infor of swagger
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "IMS Management Api",
                    Version = "v1",
                });
                // define swaggger auth
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            //

            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection authenticationSection = configuration.GetSection("Authentication");
                string googleClientId = authenticationSection["Google:ClientId"];
                string googleClientSecret = authenticationSection["Google:ClientSecret"];
                options.ClientId = googleClientId;
                options.ClientSecret = googleClientSecret;
                //options.CallbackPath = "/Auth/Signin-google";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }


            app.UseCors(IMSCorsPolicy);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}