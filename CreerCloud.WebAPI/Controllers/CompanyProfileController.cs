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
  
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>(false);
            _logic = new CompanyProfileLogic(repo);
        }
        [HttpGet]
        [Route("Profile/{id}")]
        [ResponseType(typeof(CompanyProfilePoco))]

        public IHttpActionResult GetCompanyProfile(Guid id)
        {
            CompanyProfilePoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("Profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]

        public IHttpActionResult GetAllCompanyProfile()
        {
            List<CompanyProfilePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("Profile")]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("Profile")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
