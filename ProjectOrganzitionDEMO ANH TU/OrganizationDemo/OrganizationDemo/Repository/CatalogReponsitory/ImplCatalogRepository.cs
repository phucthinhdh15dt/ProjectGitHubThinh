using OrganizationDemo.Data.CatalogIDTenantOgranzition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.CatalogReponsitory
{
    public class ImplCatalogRepository : ICatalogRepository
    {
        phucthinh1997Context db = new phucthinh1997Context();
        public bool createCatalog(CatalogOrganzitionTenant catalogOrganzitionTenant)
        {
           
                try
                {
                    var addCustome = db.CatalogOrganzitionTenant.Add(catalogOrganzitionTenant);
                    db.SaveChanges();
                    db.Dispose();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
          
        
        public bool getIdDbOfOran(string IDOrgranzition)
        {
            var find = db.CatalogOrganzitionTenant.Where(s => s.IdtenantOrgranzition.Equals(IDOrgranzition)).SingleOrDefault();
            if (find != null)
            {
                return true;
            }
            return false;
        }
    }
}
