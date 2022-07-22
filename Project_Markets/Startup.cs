using Autofac;
using Common;
using Data;
using Data.MappingProfile;
using infrastructure.WebFramework.Configuration;
using infrastructure.WebFramework.CustomMapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Attributes;
using SignalR.Bugeto.Hubs;
using System;
using WebFramework.Configoration;

namespace Project_Markets
{
    public class Startup
    {
        private readonly IdentitySettings _identitySettings;
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.InitializeAutoMapper();
            //services.AddControllersWithViews(opt => opt.Filters.Add<PermissionAuthorizeAttribute>());
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionSql"));
            });
            services.AddCustomIdentity(_identitySettings);
            var mvcBuilder = services.AddControllersWithViews();
            mvcBuilder.AddRazorRuntimeCompilation();
            //services.Configure<IdentitySettings>(Configuration.GetSection(nameof(IdentitySettings)));

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
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddRazorPages();
            services.AddControllers();
            services.AddSignalR();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddServices();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.IntializeDatabase();
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
                 endpoints.MapHub<SupportHub>("/suphub")
            );
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
