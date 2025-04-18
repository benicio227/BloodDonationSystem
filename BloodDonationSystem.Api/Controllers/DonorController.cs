using BloodDonationSystem.Application.Commands.InsertDonor;
using BloodDonationSystem.Application.Queries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertDonorCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDonorByIdQuery(id);

        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
