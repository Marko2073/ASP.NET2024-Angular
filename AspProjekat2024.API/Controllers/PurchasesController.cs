using AspProjekat2024.Application.DTO;
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
    public class PurchasesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PurchasesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        

        // POST api/<PurchasesController>
        [HttpPost]

        public IActionResult Post([FromBody] CreatePurchaseDto dto, [FromServices] ICreatePurchaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
            //da bi se menjao quantity u cartu salje se +1 ili -1, kada se dodje do 0 onda se brise iz cart-a


        }

        

        // DELETE api/<PurchasesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeletePurchaseCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
            // brisanje iz cart-a

        }
    }
}
