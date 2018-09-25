using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrganizationDemo.Data.CatalogIDTenantOgranzition;
using OrganizationDemo.Data.Models;
using OrganizationDemo.ManageOrganData;
using OrganizationDemo.Repository.CatalogReponsitory;
using OrganizationDemo.Repository.InterfaceRepository;

namespace OrganizationDemo.Controllers
{
    [Route("Organ")]
    [Produces("application/json")]
    public class OrganizationController : ControllerBase
    {
        const string _errorAdd = "19971";
        const string _errorEdit = "19972";
        const string _errorDelete = "19973";
        const string _errorRead = "19974";

        private readonly IOrganization_Reponsitory _iOrganization_Reponsitory;
        ICatalogRepository _catalogRepository;
        IMapper imapper;
        private IConfiguration _configuration;
        public OrganizationController(IOrganization_Reponsitory iOrganization_Reponsitory, IMapper _imapper, IConfiguration configuration, ICatalogRepository catalogRepository)
        {
            _iOrganization_Reponsitory = iOrganization_Reponsitory;
            imapper = _imapper;
            _configuration = configuration;
            _catalogRepository = catalogRepository;
        }
        [HttpPost("CreateOrgan")]
        public IActionResult createOrganization([FromBody] Organization org)
        {
            org.IdOrganization = Guid.NewGuid() + "";
            bool createCheck = _iOrganization_Reponsitory.CreateOrganization(org);
            if (createCheck)
            {
             var catalog=   new CatalogOrganzitionTenant()
                {
                    IdtenantOrgranzition = Guid.NewGuid()+"",
                    CatalogOrgranzitionName=org.DisplayNameDb,
                    Idorgranzition=org.IdOrganization
                };
                bool check=_catalogRepository.createCatalog(catalog);
                if (check)
                {
                    FContextFactory.Create(_configuration["TenantOrganzition"].Replace("{{tenantId}}", org.IdOrganization));
                    return Ok(createCheck);
                }
            }
            return Ok(_errorAdd);
        }
        [HttpPut("EditOrgan/id")]
        public IActionResult editOrganization([FromBody] Organization org, string id)
        {
           

            bool boolAdd = _iOrganization_Reponsitory.EditOrganization(id, org);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorEdit);


        }

        [HttpDelete("deleteOrganization")]
        public IActionResult deleteOrganization(string id)
        {

            bool boolAdd = _iOrganization_Reponsitory.deleteOrganization(id);
            if (boolAdd)
            {
                return Ok(boolAdd);
            }
            return Ok(_errorDelete);

        }

        [HttpGet("FindOrgan/id")]
        public IActionResult getFindIDOrganization(string id)
        {
            if (id.Equals(""))
            {
                return Ok("Co truong chua nhap du lieu");
            }
            try
            {
                var find = _iOrganization_Reponsitory.getFindIDOrganization(id);
                return Ok(find);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

        [HttpGet("FilterOrgan/{pageSize}/{pageNow}/{stringFilter}")]
        public IActionResult filter(int pageSize, int pageNow, string stringFilter)
        {
            try
            {
                var listProduct = _iOrganization_Reponsitory.PagingAndFilterOrganization(pageSize, pageNow, stringFilter, false);
                return Ok(listProduct);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }


        [HttpGet("CountOrgan/{stringFilter}/{conditionCount}")]
        public IActionResult CountProductFilter(string stringFilter, bool conditionCount)
        {
            try
            {
                int countFilter = _iOrganization_Reponsitory.CountOrganizationFilter(stringFilter, conditionCount);
                return Ok(countFilter);
            }
            catch (Exception)
            {

                return Ok(_errorRead);
            }

        }

    }

}