using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contrants;
using System.Text;

namespace ApiAppointmentReminder.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
       IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ef-SqlConnection")));

        public static void ConfigureServiceManager(this IServiceCollection services)
         =>  services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) 
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureJWT(this IServiceCollection services,
          IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                }
            );
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;

                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }


        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAppoinmentService, AppoinmentService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
            });
        }



    }



}
