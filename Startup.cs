using Amazon.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AmazonDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:AmazonBookStoreConnection"]);
            });

            services.AddScoped<IAmazonRepository, EFAmazonRepository>();

            services.AddRazorPages();

            //This gets the memory to stick- it helps someone to put stuff in a cart and have it stay there
            services.AddDistributedMemoryCache();
            services.AddSession();

            //CH9: storage services
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //These help us control the URLS
            // They BOTH make it easy to type URLs and make it looks good when someone navigates there
            //It goes through each of these until it finds one
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    //The curly braces denote that it's an actual object, not just a word in the url
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "Books/{pageNum:int}",
                    new {Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new {Controller = "Home", action = "Index", page = 1});

                //default endpoint which is called if they don't do anything - 
                endpoints.MapControllerRoute(
                    "pagination", //This is what is typed or inputted
                                  //"Books/{page}", this is the way from the videos
                    "P{pageNum}", //This is the format that is asked of us for assignment 6 -- this is the output
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //This line added our original seed data. after running, that data is in our database and we don't need to seed again
            SeedData.EnsurePopulated(app);
        }
    }
}
