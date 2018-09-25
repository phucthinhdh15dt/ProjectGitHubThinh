using Microsoft.AspNetCore.Mvc;
using OrganizationDemo.Data.Models;
using OrganizationDemo.Processor.Paging;
using OrganizationDemo.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.ImplRepository
{
    public class ImplOrganization_Reponsitory : IOrganization_Reponsitory
    {
        giuaKyContext db =new giuaKyContext();

        
        public bool CreateOrganization(Organization RPC)
        {
            try
            {
                var addOrganization = db.Organization.Add(RPC);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteOrganization(string id)
        {
            try
            {
                db.Organization.Remove(db.Organization.Find(id));
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditOrganization(string id, Organization RPC)
        {
            var findIdOrganization = db.Organization.Find(id);
            if (findIdOrganization != null)
            {
                findIdOrganization.NameOrganization = RPC.NameOrganization;
                findIdOrganization.DisplayNameDb = RPC.DisplayNameDb;
              

                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {

                return false;
            }
        }

        public IEnumerable<Organization> getAllOrganization()
        {
            throw new NotImplementedException();
        }

        public Organization getFindIDOrganization(string id)
        {
          return  db.Organization.Find(id);
        }

        public IEnumerable<Organization> PagingAndFilterOrganization(int pageSize, int pazeNow, string filter, bool sortBy)
        {
            IEnumerable<Organization> listProduct = PagingOrganization.PaginationGeneral(pageSize, pazeNow, sortBy, filter, db);
            return listProduct;
        }

        public int CountOrganizationFilter(string filter, bool conditionCount)
        {
            if (filter.Equals(""))
            {
                return 0;
            }
            return PagingOrganization.CountOrganizationFilter(filter, db, conditionCount);
        }

      
    }
}
