using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IronTower.Web.Controllers
{
    public class TestAPIController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok("Call successful");
        }

        // GET api/<controller>/5
        [ResponseType(typeof(int))]
        public IHttpActionResult Get(int id)
        {
            if (id != 0)
                return Ok(new { value = id });
            return BadRequest("Value not successfully returned.");
        }
        

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}