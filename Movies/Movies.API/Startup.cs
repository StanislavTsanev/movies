using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using Movies.Persistance;
using Movies.Persistance.Data;

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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            RegisterDbContext(services);
            RegisterRepositories(services);
            RegisterMediator(services);

            services.AddTransient<IData, MoviesData>();

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
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1"));
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
                //c.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();
            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<MoviesContext>(c =>
            c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAsyncRepository<UserEntity>, EfRepository<UserEntity>>();
            services.AddTransient<IAsyncRepository<MovieEntity>, EfRepository<MovieEntity>>();
            services.AddTransient<IAsyncRepository<GenreEntity>, EfRepository<GenreEntity>>();
            services.AddTransient<IAsyncRepository<MovieGenreEntity>, EfRepository<MovieGenreEntity>>();
        }

        private void RegisterMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }
    }
}
