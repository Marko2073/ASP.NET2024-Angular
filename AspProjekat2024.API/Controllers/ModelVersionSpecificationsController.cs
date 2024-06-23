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
    public class ModelVersionSpecificationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelVersionSpecificationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ModelVersionSpecificationsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelVersionSpecificationQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // GET api/<ModelVersionSpecificationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelVersionSpecificationsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateModelVersionSpecificationDto dto, [FromServices] ICreateModelVersionSpecification command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ModelVersionSpecificationsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateModelVersionSpecificationsDto dto, [FromServices] IUpdateModelVersionSpecificationsCommand command)
        {
            dto.ModelVersionId = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<ModelVersionSpecificationsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteModelVersionSpecificationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
