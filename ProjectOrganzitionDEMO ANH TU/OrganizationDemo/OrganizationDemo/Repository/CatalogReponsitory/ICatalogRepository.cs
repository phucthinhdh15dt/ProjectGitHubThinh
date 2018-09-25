using OrganizationDemo.Data.CatalogIDTenantOgranzition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.CatalogReponsitory
{
    public interface ICatalogRepository
    {
        bool createCatalog(CatalogOrganzitionTenant catalogOrganzitionTenant);
        bool getIdDbOfOran(string IDOrgranzition);
        
    }
}
