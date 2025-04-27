using BloodDonationSystem.Application.Commands.DeleteAddressById;
using BloodDonationSystem.Application.Commands.InsertAddress;
using BloodDonationSystem.Application.Commands.UpdateAddress;
using BloodDonationSystem.Application.Queries.GetAddressById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int donorId, int id)
    {
        var query = new GetAddressByIdQuery(id);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int donorId, UpdateAddressCommand command)
    {
        command.Id = donorId;

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int donorId, int id)
    {
        var query = new DeleteAddressByIdQuery(id);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
