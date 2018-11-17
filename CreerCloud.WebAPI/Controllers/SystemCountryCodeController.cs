using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            _logic = new SystemCountryCodeLogic(repo);
        }
        [HttpGet]
        [Route("CountryCode/{code")]
        [ResponseType(typeof(SystemCountryCodePoco))]

        public IHttpActionResult GetSystemCountryCode(string code)
        {
            SystemCountryCodePoco poco = _logic.Get(code);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("CountryCode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]

        public IHttpActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("CountryCode")]
        public IHttpActionResult PostSystemCountryCode([FromBody]  SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("CountryCode")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("CountryCode")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
