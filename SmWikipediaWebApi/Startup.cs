using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Middlewares;
using SmWikipediaWebApi.Models;
using SmWikipediaWebApi.Seeders;
using SmWikipediaWebApi.Services;
using SmWikipediaWebApi.Validators;
using System.Text;

namespace SmWikipediaWebApi
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
            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            services.AddControllers().AddFluentValidation();

            services.AddDbContext<WikipediaDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("Default")));

            services.AddAutoMapper(this.GetType().Assembly);

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleContentService, ArticleContentService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<Administrator>, PasswordHasher<Administrator>>();
            services.AddScoped<IValidator<AdministratorCreateDto>, AdministratorCreateDtoValidator>();

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddScoped<Seeder>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmWikipediaWebApi", Version = "v1" });
            });

            services.AddCors(setup =>
            {
                setup.AddPolicy("ui", builder =>
                {
                    builder.AllowAnyHeader().
                    AllowAnyMethod().
                    AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            seeder.Seed();

            app.UseCors("ui");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmWikipediaWebApi v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
