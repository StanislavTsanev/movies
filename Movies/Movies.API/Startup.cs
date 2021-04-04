using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.API.AutoMapper;
using Movies.API.Options;
using Movies.Application.Common.Interfaces;
using Movies.Application.Features.Movies.AutoMapper;
using Movies.Application.Features.Movies.Commands.CreateMovie;
using Movies.Application.Features.Users;
using Movies.Domain.Entities;
using Movies.Infrastructure.Identity;
using Movies.Persistance;
using Movies.Persistance.Data;
using System.Reflection;
using System.Text;

namespace Movies.API
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
            services.AddControllers();

            services.AddCors(options =>
               options.AddPolicy("default",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                }));

            services.AddAutoMapper(new Assembly[] { typeof(BmToRequestProfile).GetTypeInfo().Assembly, typeof(MovieRequestToEntityProfile).GetTypeInfo().Assembly });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            AddDbContext(services);
            AddIdentity(services);
            AddRepositories(services);
            AddMediator(services);

            services.AddTransient<IData, MoviesData>();

            services.AddSingleton<IAuthenticationOptions>(Configuration.GetSection("Auth").Get<AuthenticationOptions>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1");
            });

            app.UseAuthorization();
            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<MoviesContext>(c =>
            c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private void AddIdentity(IServiceCollection services)
        {
            services
              .AddIdentity<UserEntity, IdentityRole>(options =>
              {
                  options.Password.RequiredLength = 6;
                  options.Password.RequireDigit = false;
                  options.Password.RequireLowercase = false;
                  options.Password.RequireNonAlphanumeric = false;
                  options.Password.RequireUppercase = false;
              })
              .AddEntityFrameworkStores<MoviesContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Auth:Secret").Value))
                    };
                });

            services.AddTransient<IIdentity, IdentityService>();
            services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IAsyncRepository<MovieEntity>, EfRepository<MovieEntity>>();
            services.AddTransient<IAsyncRepository<GenreEntity>, EfRepository<GenreEntity>>();
            services.AddTransient<IAsyncRepository<MovieGenreEntity>, EfRepository<MovieGenreEntity>>();
        }

        private void AddMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateMovieCommandHandler).GetTypeInfo().Assembly);
        }
    }
}
