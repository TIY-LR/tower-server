using IronTower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IronTower.Web.Controllers
{
    public class TestAPIsController : ApiController
    {
        IronTowerDBContext db = new IronTowerDBContext();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            Game game = db.Games.FirstOrDefault();
            return Ok(game);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(int))]
        public IHttpActionResult Get(int id)
        {
            Game game = db.Games.FirstOrDefault();
            return Ok(game);
            //if (id != 0)
            //    return Ok(new { value = id });
            //return BadRequest("Value not successfully returned.");
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