using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedCourseController : ControllerBase
    {
        // GET: api/<AssignedCourseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AssignedCourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssignedCourseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssignedCourseController>
        [HttpPut]
        public void Put([FromBody] string value)
        {
        }

        // DELETE api/<AssignedCourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
