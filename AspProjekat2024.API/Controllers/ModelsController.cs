using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneModelQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ModelsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateModelDto dto, [FromServices] ICreateModelCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateModelDto dto, [FromServices] IUpdateModelCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromQuery] DeleteDto dto, [FromServices] IDeleteModelCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
