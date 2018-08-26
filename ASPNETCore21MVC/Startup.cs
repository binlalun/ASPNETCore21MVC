using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore21MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCore21MVC
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
            //GDPR用
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //上課練習
            //services.AddTransient<IAppSettings, AppSettings>();
            //services.AddScoped<IAppSettingsScoped, AppSettings>();
            //services.AddSingleton<IAppSettingsSingleton, AppSettings>();

            //設定啟用session
            services.AddDistributedMemoryCache();
            services.AddSession();

            //取得設定檔(法一)
            //var appSettings = new AppSettings();
            //Configuration.Bind(appSettings);
            //Configuration.GetSection("App").Bind(appSettings);
            //Configuration.GetSection("SMTP:TTT").Bind(appSettings);
            //services.AddSingleton<AppSettings>(appSettings);

            //取得設定檔(法二:標準作法)
            services.Configure<AppSettings>(Configuration.GetSection("SMTP:TTT"));

            //通常搭配EF的dbContext，較少直接注入連線字串
            //Configuration.GetConnectionString("DefaultConnection");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    OnPrepareResponse = ctx =>
            //    {
            //        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
            //    }
            //});

            //GDPR用
            app.UseCookiePolicy();

            //要讓MVC可以使用Session，所以要放在UseMvc之前
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("Hello");
            //    await next();
            //    await context.Response.WriteAsync("Will");
            //});

            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("Test");
            //    if (context.Request.QueryString.Value != "")
            //    {
            //        await next();
            //    }
            //    await context.Response.WriteAsync("123");
            //});

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("World");
            //});
        }
    }
}
