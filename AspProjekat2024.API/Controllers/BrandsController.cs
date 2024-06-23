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
    public class BrandsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        

        // GET: api/<BrandsController>
        [HttpGet]
        
        public IActionResult Get([FromQuery]BaseSearch search, [FromServices] IGetBrandsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBrandQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<BrandsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateBrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateBrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromQuery] DeleteDto dto, [FromServices]IDeleteBrandCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
