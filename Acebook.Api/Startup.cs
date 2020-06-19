using AcebookApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Session;

//Setting up  web applciation 
namespace Acebook.Api
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
            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.CheckConsentNeeded = context => true;
            });

            //Seting db name to look at app.json file and veriable DefaultConnection 
            services.AddDbContext<PostContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //Setting version of MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //Setting Up UI of swagger and the version 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //enable sessions on applicaiton to hold informaiton in RAM
            services.AddDistributedMemoryCache();
            services.AddSession();
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


            //Add swagger
            app.UseSwagger();


            //Set UI for swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //HTTP redirect for controllers 
            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseCookiePolicy();


        
            //Setting up Sessions 
            app.UseSession();

            
            //Setting up routing for app
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
