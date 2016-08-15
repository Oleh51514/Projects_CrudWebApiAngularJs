using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudWebApiAngularJs.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeHandler handler;
        public EmployeesController(IEmployeeHandler handler)
        {
            this.handler = handler;
        }
        // GET: api/Employees
        public IHttpActionResult Get()
        {
            var result = handler.Get().Result;
            return Ok(result);
        }
        // GET: api/Employees/5
        public IHttpActionResult Get(int id)
        {
            var result = handler.Get(id).Result;
            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();
        }
        // POST: api/Projects
        public IHttpActionResult Post(EmployeeDto data)
        {
            var result = handler.Add(data).Result;
            return Created(Url.Link("DefaultApi", new { httproute = true, controller = "Employees", id = data.Id }), result);
        }

        [Route("api/Employees/GetPageData")]
        [HttpGet]
        public IHttpActionResult GetPageData([FromUri]PagingData pagingData)
        {
            var result = handler.GetPageData(pagingData).Result;
            return Ok(result);
        }

        // PUT: api/Projects/5        
        public IHttpActionResult Put(int id, EmployeeDto data)
        {
            data.Id = id;
            var result = handler.Update(data).Result;
            return Ok(result);
        }

        // DELETE: api/Employees/5
        public IHttpActionResult Delete(int id)
        {
            handler.Delete(id);
            return Ok();
        }
    }
}
