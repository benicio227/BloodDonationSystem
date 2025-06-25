using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAppointment;
public class InsertAppointmentHandler : IRequestHandler<InsertAppointmentCommand, ResultViewModel<AppointmentViewModel>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDonorRepository _donorRepository;
    private readonly IMediator _mediator;
    public InsertAppointmentHandler(
        IAppointmentRepository appointmentRepository,
        IMediator mediator,
        IDonorRepository donorRepository)
    {
        _appointmentRepository = appointmentRepository;
        _donorRepository = donorRepository;
        _mediator = mediator;

    }
    public async Task<ResultViewModel<AppointmentViewModel>> Handle(InsertAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToEntity();

        var donor = await _donorRepository.GetById(request.DonorId);

        if (donor is null)
        {
            return ResultViewModel<AppointmentViewModel>.Error("Doador não encontrado.");
        }

        var conflict = await _appointmentRepository.ExistsConflict(request.ScheduledAt, request.Location);

        if (conflict)
        {
            return ResultViewModel<AppointmentViewModel>.Error("Horário já reservado.");
        }
 
        var appointmentExist = await _appointmentRepository.Add(appointment);

        await _mediator.Publish(new AppointmentRegisteredDomainEvent(
        
            donor.FullName,
            donor.Email,
            appointment.ScheduledAt,
            appointment.Location
        ));

        var model = AppointmentViewModel.FromEntity(appointment);

        return ResultViewModel<AppointmentViewModel>.Success(model);
    }
}
