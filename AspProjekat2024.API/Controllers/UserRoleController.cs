using AspProjekat2024.API.DTO;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Mvc;
using AuthRequest = AspProjekat2024.Application.DTO.Searches.AuthRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        
        private UseCaseHandler _handler;
        public UserRoleController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UserRoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] AuthRequest search, [FromServices] IGetUserRoleQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


    }
}
