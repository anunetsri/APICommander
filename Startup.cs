using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICommander.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace APICommander
{
    public class Startup
    {
        //Access to the configuration API
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Once configured, Swap Mock repository with Main repository need to change in here wherevever refrenced will be changed
        //3 ways to register a service within a Srvice Container(AddSingleton-Same for every request,AddScoped-created once per client,Transient-New instance created every time)
        public void ConfigureServices(IServiceCollection services)
        {
            //Use to invoke the Connection through dependency injection
            services.AddDbContext<APICommanderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            });
             //Swap here to change
            //services.AddScoped<IAPICommanderRepo, MockCommanderRepo>(); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAPICommanderRepo, SqlCommanderRepo>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Multiple bits of middleware each bit has a function which maynot be passed further in the chain.
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
