using System;
using AutoMapper;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderApp.Api.Consumers;
using OrderApp.Api.MappingProfiles;
using OrderApp.Api.MessageContract;
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
            RegisterMassTransit(services);
            RegisterAutoMapper(services);
            RegisterEntityFrameworkNpgsql(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

        private void RegisterEntityFrameworkNpgsql(IServiceCollection services)
        {
            services.AddDbContext<OrderAppContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:PostgresConnection"]));
            services.AddScoped<DbContext, OrderAppContext>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IDbFactory, DbFactory>();
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
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderAppProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void RegisterMassTransit(IServiceCollection services)
        {
            services.AddScoped<SendEmailRequest>();
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<SendEmailConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(Configuration["Rabbitmq:Url"]), hostConfigurator =>
                    {
                        hostConfigurator.Username(Configuration["Rabbitmq:UserName"]);
                        hostConfigurator.Password(Configuration["Rabbitmq:Password"]);
                    });

                    cfg.ReceiveEndpoint(host, "submit-order", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));

                        ep.ConfigureConsumer<SendEmailConsumer>(provider);
                    });
                }));
            });
        }
    }
}
