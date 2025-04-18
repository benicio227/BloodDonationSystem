using BloodDonationSystem.Application.Commands.InsertDonor;
using FluentValidation;

namespace BloodDonationSystem.Application.Validators;
public class InsertDonorValidator : AbstractValidator<InsertDonorCommand>
{
    public InsertDonorValidator()
    {
        RuleFor(d => d.FullName)
            .NotEmpty()
                .WithMessage("Nome não pode ser vazio.")
            .MaximumLength(100)
                .WithMessage("Tamanho máximo deve ser até 100 caracteres.");

        RuleFor(d => d.Email)
            .NotEmpty()
                .WithMessage("Email não pode ser vazio")
            .EmailAddress()
                .WithMessage("Email inválido.");

        RuleFor(d => d.Gender)
            .NotEmpty()
                .WithMessage("Gênero não ser ser vazio.")
            .Must(g => g == "Masculino" || g == "Feminino.")
                .WithMessage("O gênero deve ser masculino ou feminino.");

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
