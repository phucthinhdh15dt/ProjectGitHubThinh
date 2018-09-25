using OrganizationDemo.Data.Models;
using OrganizationDemo.Repository.InterfaceRepository;
using ServicesDemo.Processor.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.ImplRepository
{
    public class ImplServices_Reponsitory : IService_Reponsitory
    {
        giuaKyContext db = new giuaKyContext();


        public IEnumerable<Object> getServicesByOrganId(string OrganId,int PageSize ,int PageNow)
        {
            int skipRow = (PageNow - 1) * PageSize;
            var listServiceByOrgan = (from d in db.Services
                             join f in db.OrgServicesRent
                             on d.Idservice equals f.ServiceId
                             where f.OrgId == OrganId
                             select new
                             {
                                 
                                 ServiceName = d.ServiceName,
                                 ServiceId = f.ServiceId,
                                 PaymentDate =f.PaymentDate,
                                 EffectiveDate=f.EffectiveDate,
                                 ExpireDate=f.ExpireDate,
                                 lincenseAmount=f.LincenseAmount,
                                 license__available=f.LicenseAvailable,
                                 license__used=f.LicenseUsed,
                                 contractSignedDate=f.ContractSignedDate,
                                 contractType=f.ContractType
                             }
                             
                             ).Skip(skipRow).Take(PageSize).ToList();
            return listServiceByOrgan;
        }
        public bool CreateServices(Services RPC)
        {
            try
            {
                var addServices = db.Services.Add(RPC);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteServices(string id)
        {
            try
            {
                db.Services.Remove(db.Services.Find(id));
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditServices(string id, Services RPC)
        {
            var findIdServices = db.Services.Find(id);
            if (findIdServices != null)
            {
                findIdServices.ServiceName = RPC.ServiceName;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {

                return false;
            }
        }

        public IEnumerable<Services> getAllServices()
        {
            throw new NotImplementedException();
        }

        public Services getFindIDServices(string id)
        {
            return db.Services.Find(id);
        }

        public IEnumerable<Services> PagingAndFilterServices(int pageSize, int pazeNow, string filter, bool sortBy)
        {
            IEnumerable<Services> listProduct = PagingService.PaginationGeneral(pageSize, pazeNow, sortBy, filter, db);
            return listProduct;
        }

        public int CountServicesFilter(string filter, bool conditionCount)
        {
            if (filter.Equals(""))
            {
                return 0;
            }
            return PagingService.CountServicesFilter(filter, db, conditionCount);
        }

       
    }
}
