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
   
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
            _logic = new SecurityLoginsLogLogic(repo);
        }
        [HttpGet]
        [Route("LoginsLog/{id}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]

        public IHttpActionResult GetSecurityLoginLog(Guid id)
        {
            SecurityLoginsLogPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("LoginsLog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]

        public IHttpActionResult GetAllSecurityLoginLog()
        {
            List<SecurityLoginsLogPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("LoginsLog")]
        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("LoginsLog")]
        public IHttpActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("LoginsLog")]
        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
