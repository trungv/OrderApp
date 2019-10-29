using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderApp.Api.Services;
using OrderApp.Core.DatabaseContext;
using OrderApp.Core.Entities;
using OrderApp.Core.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OrderApp.Api
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
            RegisterSwagger(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddDbContext<OrderAppContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<OrderAppContext>();
            services.AddScoped<DbContext, OrderAppContext>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IDbFactory, DbFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async Task ConfigureAsync(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                HttpContent content;
                using (var stream = new MemoryStream())
                {
                    await httpRequest.Content.CopyToAsync(stream);
                    content = new StreamContent(stream);
                }
                httpRequest.Content.CopyToAsync(httpRequest2.Content);
                app.UseDeveloperExceptionPage();
                httpRequest.
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order App V1");
                c.DocExpansion(DocExpansion.List);
            });

            app.UseMvc();
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Order HTTP API",
                    Version = "v1",
                    Description = "The PDFMerger Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<OrderAppContext>()
               .BuildServiceProvider();
        }
    }
}
