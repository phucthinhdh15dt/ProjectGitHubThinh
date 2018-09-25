using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.InterfaceRepository
{
    public interface IService_Reponsitory
    {
        IEnumerable<Services> getAllServices();
        Services getFindIDServices(string id);
        bool CreateServices(Services RPC);
        bool EditServices(string id, Services RPC);
        bool deleteServices(string id);
        IEnumerable<Services> PagingAndFilterServices(int pageSize, int pazeNow, string filter, bool sortBy);
        int CountServicesFilter(string filter, bool conditionCount);
        IEnumerable<Object> getServicesByOrganId(string OrganId, int PageSize, int PageNow);
    }
}
