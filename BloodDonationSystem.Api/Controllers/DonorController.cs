using BloodDonationSystem.Application.Commands;
using BloodDonationSystem.Application.Commands.DeleteDonor;
using BloodDonationSystem.Application.Commands.InsertDonor;
using BloodDonationSystem.Application.Queries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        var query = new GetDonorByIdQuery(id);

        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteDonorByIdCommand(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDonorCommand command)
    {

        var result = await _mediator.Send(command);

        if (id != command.Id && command.Id != 0)
        {
            return BadRequest("O id da rota não bate com o id do corpo da requisição.");
        }

        command.Id = id;

        return NoContent();
    }


}
