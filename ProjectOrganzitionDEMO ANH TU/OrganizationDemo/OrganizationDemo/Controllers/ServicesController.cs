using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrganizationDemo.Data.Models;
using OrganizationDemo.Repository.InterfaceRepository;

namespace OrganizationDemo.Controllers
{
    [Route("Service")]
    
    [Produces("application/json")]
    public class ServicesController : ControllerBase
    {
        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        private readonly IService_Reponsitory _iServices_Reponsitory;
        IMapper imapper;
        public ServicesController(IService_Reponsitory iServices_Reponsitory, IMapper _imapper)
        {
            _iServices_Reponsitory = iServices_Reponsitory;
            imapper = _imapper;
        }

        [HttpGet("GetAllServiceByOrganId/{idOran}/{pagesize}/{pagenow}")]
        public IActionResult CountProductFilter(string idOran,int pagesize,int pagenow)
        {
            try
            {
              
                return Ok(_iServices_Reponsitory.getServicesByOrganId(idOran,pagesize,pagenow));
            }
            catch (Exception)
            {
                return Ok(_errorRead);
            }

        }

        [HttpPost("CreateServices")]
        public IActionResult createServices([FromBody] Services org)
        {
            org.Idservice = Guid.NewGuid() + "";
            bool createCheck = _iServices_Reponsitory.CreateServices(org);
            if (createCheck)
            {
                return Ok(createCheck);
            }
            return Ok(_errorAdd);
        }
        [HttpPut("EditServices/id")]
        public IActionResult editServices([FromBody] Services org, string id)
        {
           

            bool boolAdd = _iServices_Reponsitory.EditServices(id, org);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteServices")]
        public IActionResult deleteServices(string id)
        {

            bool boolAdd = _iServices_Reponsitory.deleteServices(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);

        }

        [HttpGet("FindServices/id")]
        public IActionResult getFindIDServices(string id)
        {
            if (id.Equals(""))
            {
                return Ok("Co truong chua nhap du lieu");
            }
            try
            {
                var find = _iServices_Reponsitory.getFindIDServices(id);
                return Ok(find);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }
        [HttpGet("FilterServices/{pageSize}/{pageNow}/{stringFilter}")]
        public IActionResult filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listProduct = _iServices_Reponsitory.PagingAndFilterServices(pageSize, pageNow, stringFilter, false);
                return Ok(listProduct);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountServices/{stringFilter}/{conditionCount}")]
        public IActionResult CountProductFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _iServices_Reponsitory.CountServicesFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {
                return Ok(_errorRead);
            }

        }

    }

}