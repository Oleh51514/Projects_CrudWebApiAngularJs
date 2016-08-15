using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.Common.DTO;
using System.Web.Http;

namespace CrudWebApiAngularJs.API.Controllers
{
    public class DepartmentsController : ApiController
    {

        private readonly IDepartmentHandler handler;
        public DepartmentsController(IDepartmentHandler handler)
        {
            this.handler = handler;
        }
        // GET: api/Departments
        public IHttpActionResult Get()
        {
            var result = handler.Get().Result;
            return Ok(result);
        }
        // GET: api/Departments/5
        public IHttpActionResult Get(int id)
        {
            var result = handler.Get(id).Result;
            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();
        }
        // POST: api/Departments
        public IHttpActionResult Post(DepartmentDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = handler.Add(data).Result;
            return Created(Url.Link("DefaultApi", new { httproute = true, controller = "Departments", id = data.Id }), result);
        }

        [Route("api/Departments/GetPageData")]
        [HttpGet]
        public IHttpActionResult GetPageData([FromUri]PagingData pagingData)
        {
            var result = handler.GetPageData(pagingData).Result;
            return Ok(result);
        }

        // PUT: api/Departments/5        
        public IHttpActionResult Put(int id, DepartmentDto data)
        {
            data.Id = id;
            var result = handler.Update(data).Result;
            return Ok(result);
        }

        // DELETE: api/Departments/5
        public IHttpActionResult Delete(int id)
        {
            handler.Delete(id);
            return Ok();
        }
    }
}
