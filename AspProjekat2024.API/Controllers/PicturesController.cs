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
    public class PicturesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PicturesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<PicturesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetPicturesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }
        // GET api/<PicturesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PicturesController>
        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] CreatePictureDto dto, [FromServices] ICreatePictureCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<PicturesController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public IActionResult Put(int id,[FromForm] UpdatePictureDto dto, [FromServices] IUpdatePictureCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<PicturesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromQuery] DeleteDto dto, [FromServices] IDeletePictureCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
