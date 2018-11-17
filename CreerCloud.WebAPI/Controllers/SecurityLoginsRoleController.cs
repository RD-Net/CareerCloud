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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
            _logic = new SecurityLoginsRoleLogic(repo);
        }
        [HttpGet]
        [Route("LoginsRole/{id}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]

        public IHttpActionResult GetSecurityLoginsRole(Guid id)
        {
            SecurityLoginsRolePoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("LoginsRole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]

        public IHttpActionResult GetAllSecurityLoginRole()
        {
            List<SecurityLoginsRolePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("LoginsRole")]
        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("LoginsRole")]
        public IHttpActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("LoginsRole")]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
