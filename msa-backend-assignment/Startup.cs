using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using msa_backend_assignment.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Configuration;
using msa_backend_assignment.Repository;

namespace msa_backend_assignment
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

            services.AddDbContext<TrainerDb>(options => options.UseInMemoryDatabase("items"));

            services.AddSwaggerDocument(options =>
            {
                options.DocumentName = "My Amazing API";
                options.Version = "V1.0";
            });
            services.AddHttpClient("reddit", configureClient: client =>
            {
                client.BaseAddress = new Uri("https://www.reddit.com/dev/api");
            });
            
            services.AddHttpClient(Configuration["PokemonClientName"], configureClient: client =>
            {
                client.BaseAddress = new Uri(Configuration["PokemonAddress"]);
            });

            services.AddScoped<IRepository<Trainer,int>, TrainerRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
                RequestPath = "/StaticFiles",
                EnableDefaultFiles = true

            });
            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
