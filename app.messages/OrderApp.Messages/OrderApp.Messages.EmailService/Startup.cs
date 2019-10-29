﻿using System;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderApp.Messages.Services;

namespace OrderApp.Messages.EmailService
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
            ConfigureMassTransit(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        protected virtual void ConfigureMassTransit(IServiceCollection services)
        {
            // Config MassTransit
            services.AddScoped<SendEmailConsumer>();
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<SendEmailConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri("rabbitmq://localhost"), hostConfigurator =>
                    {
                        hostConfigurator.Username("guest");
                        hostConfigurator.Password("guest");
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
