using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TemplateWebApiForMy.ConfigService.ConfigGenaral;
using TemplateWebApiForMy.ConfigService.ConfigRepository;
using AutoMapper;
using OrganizationDemo.ConfigService.ConfigGenaral;

namespace OrganizationDemo
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
            IMapperConfig.ImapperConfigService(services);
            CORSConfig.Service(services);
            services.AddMvc();
            SwaggerConfig.Service(services);
            RepositoryConfig.service(services);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            CORSConfig.app(app,"setOrigins"); 
            app.UseMvc();
            SwaggerConfig.App(app);
            
        }
    }
}
