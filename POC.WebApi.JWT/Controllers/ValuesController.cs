using System;
using System.Collections.Generic;
using System.Web.Http;

namespace POC.WebApi.JWT.Controllers
{
    [RoutePrefix("api")]
    [Authorize(Users = "PanchaNand, Pancha Nand", Roles = "")]
    public class ValuesController : ApiController
    {
        // GET: api/Values
        //[AcceptVerbs()]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        //[Route("{*date:datetime}", Name = "GetById")]
        [Route("{id:int=12}", Name = "GetById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}
