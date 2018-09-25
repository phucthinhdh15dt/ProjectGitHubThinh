using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrganizationDemo.ManageOrganData;
using OrganizationDemo.Repository.InterfaceRepository;

namespace OrganizationDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ITest application;
        IConfiguration _configuration;
        public ValuesController(ITest application, IConfiguration _configuration)
        {
            this.application = application;
            this._configuration = _configuration;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
           
            //application.test1();
            return Ok(_configuration["TenantOrganzition"]);
        }
        [HttpGet("test/{db}")]
        public IActionResult Get1(string db)
        {
            try
            {
                string a = "Server=PHUCTHINH\\SQL;Database={{tenantId}};User Id=sa;Password=1;";
                FContextFactory.Create(a.Replace("{{tenantId}}", db));
                return Ok(true);
               
            }
            catch (Exception)
            {

                return Ok(false);
            }
            
           
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
