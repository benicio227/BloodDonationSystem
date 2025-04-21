using BloodDonationSystem.Application.Commands.InsertAddress;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators;
public class InsertAddressValidator : AbstractValidator<InsertAddressCommand>
{
    public InsertAddressValidator()
    {
        RuleFor(a => a.DonorId)
            .GreaterThan(0)
                .WithMessage("O ID do doador deve ser maior que 0.");

        RuleFor(a => a.Cep)
            .NotEmpty()
                .WithMessage("O CEP é obrigatório.");
    }
}
