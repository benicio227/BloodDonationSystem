using BloodDonationSystem.Application.Commands.InsertAddress;
using BloodDonationSystem.Application.Queries.DeleteAddressById;
using BloodDonationSystem.Application.Queries.GetAddressById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers;
[Route("api/donors/{donorId}/address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(int donorId, InsertAddressCommand command)
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
        var query = new GetAddressByIdQuery(donorId);

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
        var query = new DeleteAddressByIdQuery(donorId);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
