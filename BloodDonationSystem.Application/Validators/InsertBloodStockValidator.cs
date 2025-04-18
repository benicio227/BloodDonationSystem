using BloodDonationSystem.Application.Commands.InsertBlood;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators;
public class InsertBloodStockValidator : AbstractValidator<InsertBloodStockCommand>
{
    public InsertBloodStockValidator()
    {
        RuleFor(b => b.BloodType)
            .NotEmpty()
                .WithMessage("O tipo sanguíneo é obrigatório.");

        RuleFor(b => b.RgFactor)
            .NotEmpty()
                .WithMessage("O fator RH é obrigatório.");

        RuleFor(b => b.AmountMl)
            .GreaterThanOrEqualTo(0)
                .WithMessage("A quantidade de mililitro não pode ser negativo.");
    }
}
