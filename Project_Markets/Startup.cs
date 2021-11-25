using Autofac;
using Common;
using Data;
using infrastructure.WebFramework.Configuration;
using infrastructure.WebFramework.CustomMapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.SeedServices;
using SignalR.Bugeto.Hubs;
using System;
using System.Reflection;

namespace Project_Markets
{
    public class Startup
    {
        private readonly SiteSettings _siteSetting;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews(opt => opt.Filters.Add<PermissionAuthorizeAttribute>());

            var mvcBuilder = services.AddControllersWithViews();

#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif
            services.AddSignalR();

            services.AddAutoMapper(Assembly.GetEntryAssembly());

            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.InitializeAutoMapper();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionSql"));
            });

            services.AddCustomIdentity(_siteSetting.IdentitySettings);

            #region Autentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });
            #endregion

            services.AddRazorPages();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddServices();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seedService = scope.ServiceProvider.GetRequiredService<ISeedRepository>();
                seedService.SeedAsync().GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "UserPanel",
                    areaName: "UserPanel",
                    pattern: "UserPanel/{controller=Home}/{action=Index}/{id?}",
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"),

                 endpoints.MapHub<SiteChatHub>("/chathub"),
                 endpoints.MapHub<SupportHub>("/supporthub")
            );
                endpoints.MapRazorPages();

            });


        }
    }
}
