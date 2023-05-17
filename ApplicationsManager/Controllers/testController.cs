using Api.Endpoint.Helpers.Authorizations;
using CustomerClub.Infrastracture.Utilities.TokenAuthorizationServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationsManager.Controllers
{
    [BasicAuthenticationFilter("access")]
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        // GET: api/<testController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<testController>/5
        [HttpGet("gettoken")]
        public string Gett()
        {
          
            var test = TokenAuthorizationService.MakeToken();
            return test;
        }

        // POST api/<testController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<testController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<testController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
