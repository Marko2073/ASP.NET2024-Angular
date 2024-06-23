using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVersionsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelVersionsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelVersionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelVersionQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // GET api/<ModelVersionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneModelVersionQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ModelVersionsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateModelVersionDto dto, [FromServices] ICreateModelVersionCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ModelVersionsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateModelVersionDto dto, [FromServices] IUpdateModelVersionCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<ModelVersionsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromQuery] DeleteDto dto, [FromServices] IDeleteModelVersionCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
