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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantResumeController : ApiController
    {

        private ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>(false);
            _logic = new ApplicantResumeLogic(repo);
        }
        [HttpGet]
        [Route("Resume/{id}")]
        [ResponseType(typeof(ApplicantResumePoco))]

        public IHttpActionResult GetApplicantResume(Guid id)
        {
            ApplicantResumePoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("Resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]

        public IHttpActionResult GetAllApplicantResume()
        {
            List<ApplicantResumePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("Resume")]
        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("Resume")]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("Resume")]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
