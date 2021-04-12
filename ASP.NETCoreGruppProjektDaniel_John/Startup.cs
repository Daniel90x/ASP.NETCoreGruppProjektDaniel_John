using ASP.NETCoreGruppProjektDaniel_John.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreGruppProjektDaniel_John.Models;

namespace ASP.NETCoreGruppProjektDaniel_John
{
    public class Startup // Hejsvejs test för dependaencys
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<MyUser>() // Bytat till MyUser, gamla var IdentityUser
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EventDbContext>();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options => {
                options.AccessDeniedPath = "/User/Login";
                options.LoginPath = "/User/Login";
            });


        }

        
         /*public void Configure(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();

        } */

        /* private void createRolesandUsers()
        {
            EventDbContext context = new EventDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context());
            var Usermanager = new UserManager<Application>(new.UserStore<ApplicationUser>(context));


        } */




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           /* {
                ConfigrueAuth(app);
                createRolesandUsers();
            }*/



        if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }
    }
}
