using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDemo.Processor.Paging
{
    public class PagingService
    {
        public static IEnumerable<Services> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, giuaKyContext db)
        {
            List<Services> listCustomer = new List<Services>();
            giuaKyContext ServicesContext = db;


            using (ServicesContext = new giuaKyContext())
            {

                int totalRecords = ServicesContext.Services.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listCustomer = ServicesContext.Services
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
                                return ServicesContext.Services
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return ServicesContext.Services
                                        .Where(p => p.ServiceName.Contains(filter)
                                              )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return ServicesContext.Services.ToList();
                    }
                    else
                    {
                        return new List<Services>();
                    }

                }

            }
            return listCustomer;
        }

        public static int CountServicesFilter(string filter, giuaKyContext db, bool conditionCount)
        {

            giuaKyContext ServicesContext = db;
            if (conditionCount)
            {

                int count = db.Services.Where(c => c.ServiceName.Contains(filter)

                ).Count();
                return count;
            }
            else
            {
                int count = db.Services.Count();
                return count;
            }

        }
    }
}

