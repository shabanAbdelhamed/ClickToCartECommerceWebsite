using AutoMapper;
using CickToCart.Helpers;
using CickToCart.Models;
using CickToCart.Models.User;
using CickToCart.Repositories;
using CickToCart.Repositories.Account;
using CickToCart.Repositories.ProductsRepo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CickToCart
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
           
            services.AddControllersWithViews();
            var consoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((s, level) =>
                    s == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information).AddConsole();
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt => {
                    opt.LoginPath = "/Admin/Login";
                    opt.AccessDeniedPath = "/Admin/Login";
            });
            //services.AddDbContext<ContextDataBase>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
            //});
             services.AddAutoMapper(typeof(MappingProfile));
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
             services.AddMvc();

            services.AddDbContextPool<ContextDataBase>(
               builder => builder.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"))
                   .UseLoggerFactory(consoleLoggerFactory)
                   .UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
          

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 0;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //});

            //services.AddIdentity<AppUser, IdentityRole>()
            //        .AddEntityFrameworkStores<ContextDataBase>()
            //        .AddDefaultTokenProviders();

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
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //   .AddJwtBearer(x =>
            //   {
            //       x.RequireHttpsMetadata = false;
            //       x.SaveToken = true;
            //       x.TokenValidationParameters = new TokenValidationParameters
            //       {
            //           ValidateIssuerSigningKey = true,
            //           IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSetting:SecritKey").Value)),
            //           ValidateIssuer = false,
            //           ValidateAudience = false,
            //           ValidateLifetime = true
            //       };
            //   });

            services.AddScoped<IUnitOfWork, UnitWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductsRepos, ProductsRepos>();
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            services.AddScoped<IDiscountRepo, DiscountRepo>();
            services.AddScoped<ITagRepo, TagRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailsRepo, OrderDetailsRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IShippingRepo, ShippingRepo>();
            services.AddScoped<IProduct_colorRepos, Product_colorRepos>();
            services.AddScoped<IProduct_SizeRepos, Product_SizeRepos>();
            services.AddScoped<IProduct_RatingRepos, Product_RatingRepos>();
            services.AddScoped<IAccount, Account>();
            services.AddScoped<IOrderStatusRepo, OrderStatusRepo>();
            

            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CickToCart", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CickToCart v1"));

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                  pattern: "{controller=Account}/{action=Login}/{id?}");
                      
        });
        }
    }
}
