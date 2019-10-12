using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Mediat.Models;
using FluentValidation.AspNetCore;
using AutoMapper;
using Mediat.Behaviors;
using Mediat.Context;
using Mediat.Context.EventStore;
using Mediat.Context.Dapper;
using Mediat.Repository;

namespace Mediat
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
            

            services.AddControllers()
                    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly);


            services.AddDbContext<MediatDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MediatDbContext")));
           
            services.AddSingleton<IEventStoreDbContext, EventStoreDbContext>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));


            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
