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
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            var repo = new EFGenericRepository<SecurityLoginPoco>(false);
            _logic = new SecurityLoginLogic(repo);
        }
        [HttpGet]
        [Route("Login/{id}")]
        [ResponseType(typeof(SecurityLoginPoco))]

        public IHttpActionResult GetSecurityLogin(Guid id)
        {
            SecurityLoginPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("Login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]

        public IHttpActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("Login")]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("Login")]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
