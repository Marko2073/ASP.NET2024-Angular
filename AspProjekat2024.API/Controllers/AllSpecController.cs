using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllSpecController : ControllerBase
    {
        
        private UseCaseHandler _handler;
        public AllSpecController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<AllSpecController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetAllSpecificationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<AllSpecController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AllSpecController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AllSpecController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllSpecController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
