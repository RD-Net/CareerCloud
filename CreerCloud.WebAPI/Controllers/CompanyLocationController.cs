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
    
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>(false);
            _logic = new CompanyLocationLogic(repo);
        }
        [HttpGet]
        [Route("Location/{id}")]
        [ResponseType(typeof(CompanyLocationPoco))]

        public IHttpActionResult GetCompanyLocation(Guid id)
        {
            CompanyLocationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("Location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]

        public IHttpActionResult GetAllCompanyLocation()
        {
            List<CompanyLocationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("Location")]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();

        }
        [HttpPut]
        [Route("Location")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("Location")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
