using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Test.Context;
using Test.Model.Repository;
using Test.Model;
using Test.Model.DataManager;
using Pomelo.EntityFrameworkCore.MySql;

namespace Test
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
            //services.AddDbContext<bilbixContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("bilbixDB")));
            var connectionString = "server = 94.177.229.154;user=Lazirr;password=Wkt67ssv;database=bilbix;";
            var serverVersion = new MariaDbServerVersion(MariaDbServerVersion.AutoDetect(connectionString));
            services.AddDbContext<bilbixContext>(
                DbContextOptions => DbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );


            services.AddScoped<IDataRepository<User>, UserManager>();
            services.AddScoped<IDataRepository<Order>, OrderManager>();
            services.AddScoped<IDataRepository<Produkter>, ProdukterManager>();
            services.AddScoped<IDataRepository<OrderLine>, OrderLineManager>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
