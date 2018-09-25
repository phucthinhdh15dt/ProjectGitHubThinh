using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Processor.Paging
{
    public static class PagingOrganization
    {
        public static IEnumerable<Organization> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, giuaKyContext db)
        {
            List<Organization> listCustomer = new List<Organization>();
            giuaKyContext OrganizationContext = db;


            using (OrganizationContext = new giuaKyContext())
            {

                int totalRecords = OrganizationContext.Organization.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listCustomer = OrganizationContext.Organization
                    .Skip(skipRow).Take(sizePagination)
                    .ToList();
                }
                if (filter != null && filter != "")
                {
                  
                    if (sizePagination != 0 && nowPagination != 0)
                    {
                        if (!filter.Equals("") || filter != null)
                        {
                            if (filter.Equals("ALL"))
                            {
                                return OrganizationContext.Organization
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return OrganizationContext.Organization
                                        .Where(p => p.DisplayNameDb.Contains(filter) || p.DisplayNameDb.Contains(filter)
                                            || p.NameOrganization.Contains(filter) || p.NameOrganization.Contains(filter)
                                           

                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return OrganizationContext.Organization.ToList();
                    }
                    else
                    {
                        return new List<Organization>();
                    }

                }

            }
            return listCustomer;
        }

        public static int CountOrganizationFilter(string filter, giuaKyContext  db, bool conditionCount)
        {

            giuaKyContext OrganizationContext = db;
            if (conditionCount)
            {

                int count = db.Organization.Where(c => c.NameOrganization.Contains(filter) || c.DisplayNameDb.Contains(filter)
                                    
                ).Count();
                return count;
            }
            else
            {
                int count = db.Organization.Count();
                return count;
            }

        }
    }
}
