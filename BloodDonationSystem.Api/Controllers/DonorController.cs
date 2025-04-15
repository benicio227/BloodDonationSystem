using BloodDonationSystem.Application.Commands.InsertDonor;
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
    public IActionResult Post(InsertDonorCommand command)
    {
        var result = _mediator.Send(command);

        return Created(string.Empty, result);
    }
}
