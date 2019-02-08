using System;
using System.Text;
using System.Threading.Tasks;
using BaseballCommander.Api.Models;
using BaseballCommander.Application.Repositories;
using BaseballCommander.Application.Users;
using BaseballCommander.Application.Users.Commands.CreateUser;
using BaseballCommander.Application.Users.Queries.AuthenticateUser;
using BaseballCommander.Application.Users.Queries.GetUser;
using BaseballCommander.Data.EFCore;
using BaseballCommander.Data.EFCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BaseballCommander.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.AddDbContext<BaseballCommanderContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("BaseballCommanderConnection")));

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IGetUserQuery>();
                            var userId = Guid.Parse(context.Principal.Identity.Name);
                            var user = userService.Execute(userId);
                            if (user == null)
                            {
                                // return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<IRepositoryContainer, RepositoryContainer>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IAuthenticateUserQuery, AuthenticateUserQuery>();
            services.AddScoped<IGetUserQuery, GetUserQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
