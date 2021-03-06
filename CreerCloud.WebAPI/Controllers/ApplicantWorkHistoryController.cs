﻿using CareerCloud.BusinessLogicLayer;
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
    public class ApplicantWorkHistoryController : ApiController
    { 
    private ApplicantWorkHistoryLogic _logic;

    public ApplicantWorkHistoryController()
    {
        var repo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
        _logic = new ApplicantWorkHistoryLogic(repo);
    }
    [HttpGet]
    [Route("WorkHistory/{id}")]
    [ResponseType(typeof(ApplicantEducationPoco))]

    public IHttpActionResult GetApplicantWorkHistory(Guid id)
    {
            ApplicantWorkHistoryPoco poco = _logic.Get(id);
        if (poco == null)
        {
            return NotFound();
        }
        return Ok(poco);
    }

    [HttpGet]
    [Route("WorkHistory")]
    [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]

    public IHttpActionResult GetAllApplicantWorkHistory()
    {
        List<ApplicantWorkHistoryPoco> poco = _logic.GetAll();
        if (poco == null)
        {
            return NotFound();
        }
        return Ok(poco);
    }
    [HttpPost]
    [Route("WorkHistory")]
    public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
    {
        _logic.Add(pocos);
        return Ok();

    }
    [HttpPut]
    [Route("WorkHistory")]
    public IHttpActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
    {
        _logic.Update(pocos);
        return Ok();
    }
    [HttpDelete]
    [Route("WorkHistory")]
    public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
    {
        _logic.Delete(pocos);
        return Ok();
    }
}
}

