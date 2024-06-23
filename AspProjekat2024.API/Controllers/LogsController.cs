using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        
        private UseCaseHandler _handler;
        public LogsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<LogsController>
        [HttpGet]
        [Authorize]

        public IActionResult Get([FromQuery] LogsSearch search, [FromServices] IGetLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

    }
}
