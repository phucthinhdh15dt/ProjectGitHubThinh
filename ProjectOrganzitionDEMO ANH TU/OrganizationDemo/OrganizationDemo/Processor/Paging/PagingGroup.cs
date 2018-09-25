

using OrganizationDemo.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationDemo.Processor.Paging
{
    public class PagingGroup
    {
        public static IEnumerable<Group> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, giuaKyContext db)
        {
            List<Group> listCustomer = new List<Group>();
            giuaKyContext GroupContext = db;
            

            using (GroupContext = new giuaKyContext())
            {

                int totalRecords = GroupContext.Group.Count();
                int skipRow = (nowPagination - 1) * sizePagination;
                if (dest)
                {
                    listCustomer = GroupContext.Group
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
                                return GroupContext.Group
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                            else
                            {
                                return GroupContext.Group
                                        .Where(p => p.GroupIdChildren.Contains(filter) || p.GroupName.Contains(filter)
                                        )
                                        .Skip(skipRow).Take(sizePagination)
                                        .ToList();
                            }
                        }



                    }
                    if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
                    {
                        return GroupContext.Group.ToList();
                    }
                    else
                    {
                        return new List<Group>();
                    }

                }

            }
            return listCustomer;
        }

        public static int CountGroupFilter(string filter, giuaKyContext db, bool conditionCount)
        {

            giuaKyContext GroupContext = db;
            if (conditionCount)
            {

                int count = db.Group.Where(c => c.GroupIdChildren.Contains(filter) || c.GroupName.Contains(filter)

                ).Count();
                return count;
            }
            else
            {
                int count = db.Group.Count();
                return count;
            }

        }
    }
}
