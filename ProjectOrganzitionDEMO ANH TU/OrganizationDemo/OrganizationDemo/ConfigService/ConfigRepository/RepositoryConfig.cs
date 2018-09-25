using GroupDemo.Repository.InterfaceRepository;
using Microsoft.Extensions.DependencyInjection;
using OrganizationDemo.Repository.CatalogReponsitory;
using OrganizationDemo.Repository.ImplRepository;
using OrganizationDemo.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateWebApiForMy.ConfigService.ConfigRepository
{
    public static class RepositoryConfig
    {
        public static void service(IServiceCollection services)
        {
            services.AddTransient<IOrganization_Reponsitory, ImplOrganization_Reponsitory>();
            services.AddTransient<IService_Reponsitory, ImplServices_Reponsitory>();
            services.AddTransient<IGroup_Reponsitory, ImplGroup_Reponsitory>();
            services.AddTransient<ICatalogRepository, ImplCatalogRepository>();
            services.AddTransient<ITest, ImplTest>();
        }
    }
}
