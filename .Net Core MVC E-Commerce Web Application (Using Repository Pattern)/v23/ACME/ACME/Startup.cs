using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACME.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ACME.Data.Interfaces;
using ACME.Data.Repositories;
using ACME.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using ACME.Services;
using System.IO;
using ReflectionIT.Mvc.Paging;

namespace ACME
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            string path = Directory.GetCurrentDirectory();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    .Replace("[DataDirectory]", path)));

            services.AddScoped<IUserClaimsPrincipalFactory<AccountUser>,
               UserClaimsPrincipalFactory<AccountUser, IdentityRole>>();

            services.AddDefaultIdentity<AccountUser>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
                config.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(0);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )

            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddSession();
            services.AddPaging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context, UserManager<AccountUser> userManager, IServiceProvider serviceProvider)
        {

            // Ensure the database has been created
            context.Database.EnsureCreatedAsync().Wait();

            // Create the roles if the have not already been created in the web application
            CreateRoles(serviceProvider).Wait();

            // Seed the database if it does not contain any records
            DbInitializer.Seed(context, userManager);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            // Set routes
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "orderRedirectToCart",
                    template: "ShoppingCart/Checkout",
                    defaults: new { Controller = "ShoppingCart", action = "Index" });

                routes.MapRoute(
                    name: "productDetailsRedirectToCart",
                    template: "ShoppingCart/Details",
                    defaults: new { Controller = "ShoppingCart", action = "Index" });

                routes.MapRoute(
                    name: "productsRedirectToCart",
                    template: "ShoppingCart/List",
                    defaults: new { Controller = "ShoppingCart", action = "Index" });

                routes.MapRoute(
                    name: "transactionsRedirectToCart",
                    template: "ShoppingCart/CustomerTransactions",
                    defaults: new { Controller = "ShoppingCart", action = "Index" });

                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Product/{action}/{category?}",
                    defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }

        // Method used to create roles in the web application (Customer and Admin)
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            // Initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Customer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them in the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

        }

    }
}
