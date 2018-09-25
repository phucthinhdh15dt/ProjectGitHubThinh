using GroupDemo.Repository.InterfaceRepository;
using OrganizationDemo.Data.Models;
using OrganizationDemo.Processor.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.Repository.ImplRepository
{
    public class ImplGroup_Reponsitory : IGroup_Reponsitory
    {
        giuaKyContext db = new giuaKyContext();


        public bool CreateGroup(Group RPC)
        {
            try
            {
                var addGroup = db.Group.Add(RPC);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteGroup(string id)
        {
            try
            {
                db.Group.Remove(db.Group.Find(id));
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditGroup(string id, Group RPC)
        {
            var findIdGroup = db.Group.Find(id);
            if (findIdGroup != null)
            {
                findIdGroup.GroupIdChildren = RPC.GroupIdChildren;
                findIdGroup.GroupName = RPC.GroupName;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {

                return false;
            }
        }

        public IEnumerable<Group> getAllGroup()
        {
            throw new NotImplementedException();
        }

        public Group getFindIDGroup(string id)
        {
            return db.Group.Find(id);
        }

        public IEnumerable<Group> PagingAndFilterGroup(int pageSize, int pazeNow, string filter, bool sortBy)
        {
            IEnumerable<Group> listProduct = PagingGroup.PaginationGeneral(pageSize, pazeNow, sortBy, filter, db);
            return listProduct;
        }

        public int CountGroupFilter(string filter, bool conditionCount)
        {
            if (filter.Equals(""))
            {
                return 0;
            }
            return PagingGroup.CountGroupFilter(filter, db, conditionCount);
        }

        public IEnumerable<Group> GetListGroupByOrganID(string oranID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetListGroupByGroupChidlrenID(string group_children_ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> getListRoleByGroupID(string groupID)
        {
            throw new NotImplementedException();
        }
    }
    }
