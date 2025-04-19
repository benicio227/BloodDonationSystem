using BloodDonationSystem.Application.Commands.DeleteBlood;
using BloodDonationSystem.Application.Commands.InsertBlood;
using BloodDonationSystem.Application.Queries.GetAllBloodStock;
using BloodDonationSystem.Application.Queries.GetBloodStockById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Created(string.Empty, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllBloodStockQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBloodStockByIdQuery(id));

            if (result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBloodStockCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
