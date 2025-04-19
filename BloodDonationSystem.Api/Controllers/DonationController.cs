using BloodDonationSystem.Application.Commands.InsertDonation;
using BloodDonationSystem.Application.Queries.DeleteDonationById;
using BloodDonationSystem.Application.Queries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers;
[Route("api/donors/{donorId}/donations")]
[ApiController]
public class DonationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationController(IMediator mediator)
    {
        _mediator = mediator;   
    }

    [HttpPost]
    public async Task<IActionResult> Post(int donorId, InsertDonationCommand command)
    {
        command.DonorId = donorId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Created(string.Empty, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int donorId)
    {
        var query = new GetDonationByIdQuery(donorId);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int donorId)
    {
        var query = new DeleteDonationByIdQuery(donorId);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
