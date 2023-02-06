using IdentityServer4.AccessTokenValidation;
using Microsoft.OpenApi.Models;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using ProjetoPratico.Infraestructure.Data.DifficultyLevel.Repository;
using ProjetoPratico.Infraestructure.Data.Ingredient.Repository;
using ProjetoPratico.Infraestructure.Data.Recipe.Repository;
using ProjetoPratico.Infraestructure.Data.RecipeCategory.Repository;
using ProjetoPratico.Infraestructure.Data.User.Repository;

namespace ProjetoPratico.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPratico.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICookUnitOfWork, CookUnitOfWork>();
            services.AddScoped<IDifficultyLevelRepository, DifficultyLevelRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(
                   options =>
                   {
                       options.Authority = "http://localhost:7035/";
                       options.ApiName = "projetopraticoapi";
                   });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoPratico.API", Version = "v1" });
            });

            services.AddCors();
        }

        

    }
}
