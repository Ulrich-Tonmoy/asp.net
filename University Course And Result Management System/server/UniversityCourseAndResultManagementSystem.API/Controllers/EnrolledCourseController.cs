using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityCourseAndResultManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledCourseController : ControllerBase
    {
        // GET: api/<EnrolledCourseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnrolledCourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnrolledCourseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnrolledCourseController>
        [HttpPut]
        public void Put([FromBody] string value)
        {
        }

        // DELETE api/<EnrolledCourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
