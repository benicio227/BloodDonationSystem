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

        RuleFor(a => a.Street)
            .NotEmpty()
                .WithMessage("O nome do endereço da rua é obrigatório.");

        RuleFor(a => a.City)
            .NotEmpty()
                .WithMessage("O nome da cidade é obrigatório.");

        RuleFor(a => a.State)
            .NotEmpty()
                .WithMessage("O nome do estado é obrigatório.");

        RuleFor(a => a.Cep)
            .NotEmpty()
                .WithMessage("O CEP é obrigatório.");
    }
}
