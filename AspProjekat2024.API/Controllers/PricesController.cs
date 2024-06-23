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
    public class PricesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PricesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<PricesController>
        [HttpGet]
        public IActionResult Get([FromQuery] PriceSearch search, [FromServices] IGetPriceQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // GET api/<PricesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PricesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePriceDto dto, [FromServices] ICreatePriceCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

        // PUT api/<PricesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id,[FromBody] UpdatePriceDto dto, [FromServices] IUpdatePriceCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);



        }

        // DELETE api/<PricesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromQuery] DeleteDto dto, [FromServices] IDeletePriceCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
