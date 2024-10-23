using Application;
using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartDTO>>> GetCarts()
        {
            return await mediator.Send(new GetCartsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCart(CreateCartCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction("GetById", new { Id = id }, id);
        }

        [HttpGet("id")]
        public async Task<ActionResult<CartDTO>> GetById(Guid id)
        {
            return await mediator.Send(new GetCartQuery { Id = id });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteCartCommand { Id = id });
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, UpdateCartCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
