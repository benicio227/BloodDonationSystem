using BloodDonationSystem.Application.Commands.InsertDonor;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators;
public class InsertDonorValidator : AbstractValidator<InsertDonorCommand>
{
    public InsertDonorValidator()
    {
        RuleFor(d => d.FullName)
            .NotEmpty()
                .WithMessage("O nome é obrigatório.")
            .MaximumLength(100)
                .WithMessage("O tamanho máximo deve ser de até 100 caracteres.");

        RuleFor(d => d.Gender)
            .NotEmpty()
                .IsInEnum()
                .WithMessage("O gênero é obrigatório.");

        RuleFor(d => d.Weight)
            .GreaterThanOrEqualTo(50)
                .WithMessage("O peso deve ser igual ou maior que 50kg.");

        RuleFor(d => d.BloodType)
            .NotEmpty()
                .WithMessage("O tipo sanguíneo é obrigatório.");

        RuleFor(d => d.RgFactor)
            .NotEmpty()
                .WithMessage("O fator RH é obrigatório.");

    }
}
