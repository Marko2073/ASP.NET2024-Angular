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
    public class SpecificationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public SpecificationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<SpecificationsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetSpecificationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<SpecificationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneSpecificationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        // POST api/<SpecificationsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateSpecificationDto dto, [FromServices] ICreateSpecificationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<SpecificationsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateSpecificationDto dto, [FromServices] IUpdateSpecificationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<SpecificationsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteSpecificationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
