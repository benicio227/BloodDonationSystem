using BloodDonationSystem.Application.Commands.InsertAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.Api.Controllers
{
    [Route("api/donors/{donorId}/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int donorId, InsertAppointmentCommand command)
        {
            command.DonorId = donorId;

            var result = await _mediator.Send(command);


            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Created(string.Empty, result);
        }
    }
}
