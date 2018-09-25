using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupDemo.Repository.InterfaceRepository
{
    public interface IGroup_Reponsitory
    {
        IEnumerable<Group> getAllGroup();
        Group getFindIDGroup(string id);
        bool CreateGroup(Group RPC);
        bool EditGroup(string id, Group RPC);
        bool deleteGroup(string id);
        IEnumerable<Group> PagingAndFilterGroup(int pageSize, int pazeNow, string filter, bool sortBy);
        int CountGroupFilter(string filter, bool conditionCount);
        //danh sach group theo organzitionId
        IEnumerable<Group> GetListGroupByOrganID(string oranID);
        //danh sach group con theo groupID cha
        IEnumerable<Group> GetListGroupByGroupChidlrenID(string group_children_ID);
        //lay danh sach role theo group id 
        IEnumerable<Role> getListRoleByGroupID(string groupID);
    }
}
