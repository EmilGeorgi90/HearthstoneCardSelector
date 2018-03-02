using HsDbFirstRealAspNetProject.Data;
using HsDbFirstRealAspNetProject.Models;
using HsDbFirstRealAspNetProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;

namespace HsDbFirstRealAspNetProject
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


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            string assemblyName = typeof(ApplicationDbContext).Namespace;
            services.AddDbContext<HsDbFirstRealAspNetProjectContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HsDbFirstRealAspNetProjectContext"), b => b.MigrationsAssembly(assemblyName)));
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDirectoryBrowser();
            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Create", policy => policy.RequireRole("administrator"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStaticFiles(); // For the wwwroot folder
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                    RequestPath = "/MyImages"
                });

                app.UseDirectoryBrowser(new DirectoryBrowserOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                    RequestPath = "/MyImages"
                });

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CardInfoes}/{action=Index}/{id?}");
            });
            createRolesandUsers();
        }
        private async void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            var serviceProvider = new DefaultServiceProviderFactory().CreateServiceProvider(new ServiceCollection());
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context), new List<RoleValidator<IdentityRole>>(), new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), new Logger<RoleManager<IdentityRole>>(new LoggerFactory()));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context), Options.Create<IdentityOptions>(new IdentityOptions()), new PasswordHasher<ApplicationUser>(Options.Create<PasswordHasherOptions>(new PasswordHasherOptions())), new List<UserValidator<ApplicationUser>>(), new List<PasswordValidator<ApplicationUser>>(), new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), serviceProvider, new Logger<UserManager<ApplicationUser>>(new LoggerFactory()));
            IdentityResult result;
            if (await UserManager.FindByNameAsync("emil.georgi90@gmail.com") is ApplicationUser user)
            {
                result = await UserManager.AddToRoleAsync(user, "Admin");
            }
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!await roleManager.RoleExistsAsync("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNetCore.Identity.IdentityRole("admin")
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(role);

                //Here we create a Admin super user who will maintain the website                  

                //var user = new ApplicationUser();
                //user.UserName = "Emil";
                //user.Email = "something@gmail.com";

                //string userPWD = "Peevee1998!";

                //var chkUser = await UserManager.CreateAsync(user, userPWD);

                ////Add default User to Role Admin   
                //if (chkUser.Succeeded)
                //{
                //    var result1 = UserManager.AddToRoleAsync(user, "Admin");

                //}
            }

            // creating Creating Manager role    
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var role = new Microsoft.AspNetCore.Identity.IdentityRole();
                role.Name = "Manager";
                await roleManager.CreateAsync(role);

            }

            // creating Creating Employee role    
            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                var role = new Microsoft.AspNetCore.Identity.IdentityRole();
                role.Name = "Employee";
                await roleManager.CreateAsync(role);

            }
        }
    }
}
