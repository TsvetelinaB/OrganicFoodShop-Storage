using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Infrastructure;
using OrganicFoodShop.Services.Employees;
using OrganicFoodShop.Services.Products;

namespace OrganicFoodShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options =>
                         options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
                 .AddDefaultIdentity<User>(options =>
                 {
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.SignIn.RequireConfirmedAccount = false;
                    })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ShopDbContext>();

            services.AddControllersWithViews();
         
            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(options =>
                options.AllowAnyOrigin());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "paging",
                    pattern: "{controller=Products}/{action=All}/{currentPage?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
