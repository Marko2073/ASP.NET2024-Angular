using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.DTO.Searches;
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
    public class ProductsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductsSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneModelVersionQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ProductsController>
        [HttpPost]

        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromBody] InsertProductDto dto, [FromServices] ICreateProductCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteModelVersionCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
