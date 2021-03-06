using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BulkBookOutlet.DataAccess.Data;
using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.DataAccess.Data.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using BulkBookOutlet.Utility;
using Stripe;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BulkBookOutlet
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            services.Configure<EmailOptions>(option =>
            {
                option.SendGridKey = Environment.GetEnvironmentVariable("sendgridKey", EnvironmentVariableTarget.User);
                option.SendGridUser = Environment.GetEnvironmentVariable("sendgridUser", EnvironmentVariableTarget.User);
            });
            services.Configure<StripeSettings>(option =>
            {
                option.PublishedKey = Environment.GetEnvironmentVariable("stripePublishKey", EnvironmentVariableTarget.User);
                option.SecretKey = Environment.GetEnvironmentVariable("stripeSecretKey", EnvironmentVariableTarget.User);
            });
            services.Configure<TwilioSettings>(option =>
            {
                option.PhoneNumber = Environment.GetEnvironmentVariable("twPhoneNumber", EnvironmentVariableTarget.User);
                option.AccountSid = Environment.GetEnvironmentVariable("twAccountSID", EnvironmentVariableTarget.User);
                option.AuthToken = Environment.GetEnvironmentVariable("twAuthToken", EnvironmentVariableTarget.User);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = Environment.GetEnvironmentVariable("facebookID", EnvironmentVariableTarget.User);
                options.AppSecret = Environment.GetEnvironmentVariable("facebookSecret", EnvironmentVariableTarget.User);
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("googleID", EnvironmentVariableTarget.User);
                options.ClientSecret = Environment.GetEnvironmentVariable("googleSecret", EnvironmentVariableTarget.User);
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("stripeSecretKey", EnvironmentVariableTarget.User);
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { //template : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
