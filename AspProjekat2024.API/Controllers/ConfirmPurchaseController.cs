using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmPurchaseController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ConfirmPurchaseController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        
        // POST api/<ConfirmPurchaseController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateConfirmPurchaseDto dto, [FromServices] ICreateConfirmPurchaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

    }
}
