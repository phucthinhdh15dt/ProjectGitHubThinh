using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.InterfaceRepository
{
   public interface IOrganization_Reponsitory
    {
        IEnumerable<Organization> getAllOrganization();
        Organization getFindIDOrganization(string id);
        bool CreateOrganization(Organization RPC);
        bool EditOrganization(string id, Organization RPC);
        bool deleteOrganization(string id);
        IEnumerable<Organization> PagingAndFilterOrganization(int pageSize, int pazeNow, string filter, bool sortBy);
        int CountOrganizationFilter(string filter, bool conditionCount);
    }
}
