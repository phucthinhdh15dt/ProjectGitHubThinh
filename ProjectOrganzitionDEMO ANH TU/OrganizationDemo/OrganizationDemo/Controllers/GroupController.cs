using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GroupDemo.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrganizationDemo.Data.Models;
using OrganizationDemo.ModelsClient;
using OrganizationDemo.Repository.InterfaceRepository;

namespace OrganizationDemo.Controllers
{
    [Route("Group")]
    [Produces("application/json")]
    public class GroupController : ControllerBase
    {
        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        private readonly IGroup_Reponsitory _iGroup_Reponsitory;
        IMapper imapper;
        public GroupController(IGroup_Reponsitory iGroup_Reponsitory, IMapper _imapper)
        {
            _iGroup_Reponsitory = iGroup_Reponsitory;
            imapper = _imapper;
        }
        [HttpPost("CreateOrgan")]
        public IActionResult createGroup([FromBody] Group group)
        {
            group.GroupId = Guid.NewGuid() + "";
            bool createCheck = _iGroup_Reponsitory.CreateGroup(group);
            if (createCheck)
            {
                return Ok(createCheck);
            }
            return Ok(_errorAdd);
        }
        [HttpPut("EditOrgan/id")]
        public IActionResult editGroup([FromBody] Group group, string id)
        {


            bool boolAdd = _iGroup_Reponsitory.EditGroup(id, group);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteGroup")]
        public IActionResult deleteGroup(string id)
        {

            bool boolAdd = _iGroup_Reponsitory.deleteGroup(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);

        }

        [HttpGet("FindGroup/id")]
        public IActionResult getFindIDGroup(string id)
        {
            if (id.Equals(""))
            {
                return Ok("Co truong chua nhap du lieu");
            }
            try
            {
                var find = _iGroup_Reponsitory.getFindIDGroup(id);
                return Ok(find);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpGet("FilterGroup/{pageSize}/{pageNow}/{stringFilter}")]
        public IActionResult filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listProduct = _iGroup_Reponsitory.PagingAndFilterGroup(pageSize, pageNow, stringFilter, false);
                return Ok(listProduct);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountGroup/{stringFilter}/{conditionCount}")]
        public IActionResult CountProductFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _iGroup_Reponsitory.CountGroupFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

    }

}