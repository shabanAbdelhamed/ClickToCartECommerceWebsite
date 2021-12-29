using CickToCart.Helpers;
using CickToCart.Models;
using CickToCart.Models.User;
using CickToCart.Repositories;
using CickToCart.Repositories.Account;
using CickToCart.Repositories.CartDetailsRepo;
using CickToCart.Repositories.CartRepo;
using CickToCart.Repositories.ProductsRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickToCartWebApi
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

            var consoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((s, level) =>
                    s == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information).AddConsole();
            });

            services.AddDbContextPool<ContextDataBase>(
              builder => builder.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"))
                  .UseLoggerFactory(consoleLoggerFactory)
                  .UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
           

            services.AddScoped<IUnitOfWork, UnitWork>();
            services.AddScoped<ITagRepo, TagRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IDiscountRepo, DiscountRepo>();
            services.AddScoped<IOrderDetailsRepo, OrderDetailsRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ICartRepo, Cart_Repo>();
            services.AddScoped<ICartDetailsRepo, CartDetails_Repo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IProductsRepos, ProductsRepos>();
            services.AddScoped<IProduct_colorRepos, Product_colorRepos>();
            services.AddScoped<IProduct_SizeRepos, Product_SizeRepos>();
            services.AddScoped<IProduct_RatingRepos, Product_RatingRepos>();
            services.AddScoped<IShippingRepo, ShippingRepo>();
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IAccount, Account>();


           
            //config identity
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ContextDataBase>().AddDefaultTokenProviders();

            //config  jwt token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSetting:SecritKey").Value)),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true
                   };
               });
            services.AddMvc(setupAction => {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
             .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddScoped(typeof(IRepository<>),
                        typeof(Repository<>));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClickToCartWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClickToCartWebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
