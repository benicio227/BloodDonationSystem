using BloodDonationSystem.Application.Commands.DeleteBlood;
using BloodDonationSystem.Application.Commands.InsertBlood;
using BloodDonationSystem.Application.Queries.GetAllBloodStock;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllBloodStockQuery());


            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBloodStockCommand(id));

            return NoContent();
        }
    }
}
