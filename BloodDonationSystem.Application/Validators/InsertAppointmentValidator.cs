using BloodDonationSystem.Application.Commands.InsertAppointment;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators
{
    public class InsertAppointmentValidator : AbstractValidator<InsertAppointmentCommand>
    {
        public InsertAppointmentValidator()
        {
            RuleFor(a => a.Location)
                .IsInEnum().WithMessage("Local inválido.");
        }
    }
}
